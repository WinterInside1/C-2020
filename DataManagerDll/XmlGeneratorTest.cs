using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace DataManagerDll
{
    public class XmlGenerator
    {
        readonly string outputFolder;

        public XmlGenerator(string outputFolder)
        {
            this.outputFolder = outputFolder;
        }
        public async Task WriteToXmlAsync(DataSet dataSet,string fileName) 
        {

            dataSet.WriteXml(Path.Combine(outputFolder, $"{fileName}.xml"));
            await WriteToXmlAsync( dataSet, fileName); 
        }
    }
}
