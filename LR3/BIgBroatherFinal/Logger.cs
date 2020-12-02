using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.IO;
using System.Threading;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace BIgBroatherFinal
{
    public class Logger

    {
        private List<Portfolio> folders;
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        public Logger(Settings settings)
        {
            folders = settings.Folders;
            watcher = new FileSystemWatcher(folders.Find(x => x.Title == "Source").TitlePath);
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
        }
        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }
        private void Record(string filePath, string fileEvent)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter("C:\\services\\sourcelog.txt", true))
                {
                    writer.WriteLine(string.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }
        private void RecordException(string ex)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter("C:\\services\\sourcelog.txt", true))
                {
                    writer.WriteLine("Возникло исключение: " + ex);
                    writer.Flush();
                }
            }
        }
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Record(e.OldFullPath, "переименован в " + e.FullPath);
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Record(e.FullPath, "изменен");
            Watcher_Created(sender, e);
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Record(e.FullPath, "удален");
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (Path.GetExtension(e.FullPath) == ".txt")
                {
                    FileInfo file = new FileInfo(e.FullPath);
                    string targetFile = Path.Combine(folders.Find(x => x.Title == "Archive").TitlePath,
                        string.Format("{0:yyyy}\\{0:MM}\\{0:dd}", file.CreationTime));
                    if (!Directory.Exists(targetFile))
                    {
                        Directory.CreateDirectory(targetFile);
                    }
                    targetFile = Path.Combine(targetFile, string.Format("Sales_{0:yyyy}_{0:MM}_{0:dd}_{0:HH}_{0:mm}_{0:ss}.txt", file.CreationTime));
                    EncryptFile(e.FullPath, targetFile);
                    string newSource = Path.ChangeExtension(targetFile, ".gz");
                    CompressFile(targetFile, newSource);
                    DeleteFile(targetFile);
                    string finalTarget = Path.Combine(Path.GetDirectoryName(targetFile), "archive");
                    if (!Directory.Exists(finalTarget))
                    {
                        Directory.CreateDirectory(finalTarget);
                    }
                    finalTarget = Path.Combine(finalTarget, Path.ChangeExtension(Path.GetFileName(newSource), ".txt"));
                    DecompressFile(newSource, finalTarget);
                    DecryptFile(finalTarget, finalTarget);
                }
                Record(e.FullPath, "создан");
            }
            catch (Exception ex)
            {
                RecordException(ex.Message);
            }
        }
        private void EncryptFile(string sourcePath, string targetPath)
        {
            byte[] data;
            using (StreamReader reader = new StreamReader(sourcePath))
            {
                data = Encoding.ASCII.GetBytes(reader.ReadToEnd());
            }
            FileStream target;
            if (File.Exists(targetPath))
            {
                target = new FileStream(targetPath, FileMode.OpenOrCreate);
            }
            else
            {
                target = File.Create(targetPath);
            }
            using (target)
            {
                Aes aes = Aes.Create();
                byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                using (CryptoStream cryptoStream = new CryptoStream(target, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                }
            }
        }
        private void CompressFile(string sourcePath, string targetPath)
        {
            using (FileStream source = new FileStream(sourcePath, FileMode.OpenOrCreate))
            {
                using (FileStream target = File.Create(targetPath))
                {
                    using (GZipStream compression = new GZipStream(target, CompressionMode.Compress))
                    {
                        source.CopyTo(compression);
                    }
                }
            }
        }
        private void DeleteFile(string path)
        {
            File.Delete(path);
        }
        private void DecompressFile(string sourcePath, string targetPath)
        {
            using (FileStream source = new FileStream(sourcePath, FileMode.OpenOrCreate))
            {
                using (FileStream target = File.Create(targetPath))
                {
                    using (GZipStream decompressionStream = new GZipStream(source, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(target);
                    }
                }
            }
        }
        private void DecryptFile(string sourcePath, string targetPath)
        {
            using (FileStream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                if (!File.Exists(targetPath))
                {
                    File.Create(targetPath);
                }
                string data;
                Aes aes = Aes.Create();
                byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                using (CryptoStream cryptoStream = new CryptoStream(source, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cryptoStream))
                    {
                        data = reader.ReadToEnd();
                    }
                }
                using (StreamWriter writer = new StreamWriter(targetPath, false))
                {
                    writer.Write(data);
                }
            }
        }
    }
}
