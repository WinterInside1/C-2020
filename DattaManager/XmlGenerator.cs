using System.Data;
using System.IO;

namespace DataManagerDll
{
    public class XmlGenerator
    {
        readonly string outputFolder;

        public XmlGenerator(string outputFolder)
        {
            this.outputFolder = outputFolder;
        }

        public void WriteToXml(DataSet dataSet, string fileName)
        {
            dataSet.WriteXml(Path.Combine(outputFolder, $"{fileName}.xml"));

        }
    }
}
