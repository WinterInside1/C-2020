using System.IO;
using System.Threading.Tasks;

namespace DataManagerDll
{
    public class DataTransfer
    {
        readonly string sourceFolder;

        readonly string outputFolder;

        public DataTransfer(string outputFolder, string sourceFolder)
        {
            this.sourceFolder = sourceFolder;

            this.outputFolder = outputFolder;
        }

/*        public void SendDataToFileManager(string fileName)
        {
            if (File.Exists(Path.Combine(sourceFolder, fileName)))
            {
                File.Delete(Path.Combine(sourceFolder, fileName));
            }

            File.Copy(Path.Combine(outputFolder, fileName), Path.Combine(sourceFolder, fileName));
        }*/
        public async Task SendDataToFileManagerAsync(string fileName) 
        {
            if (File.Exists(Path.Combine(sourceFolder, fileName)))
            {
                File.Delete(Path.Combine(sourceFolder, fileName));
            }

            File.Copy(Path.Combine(outputFolder, fileName), Path.Combine(sourceFolder, fileName));

            await SendDataToFileManagerAsync(fileName);

        }
    }
}
