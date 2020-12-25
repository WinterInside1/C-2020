using System.IO;
using System;
using System.Threading.Tasks;



namespace ParserDll
{
   public class Manager
    {
        private readonly IParse parser;
        public Manager(string path,Type mainType)
        {
            if (path.EndsWith(".xml"))
            {
                XmlParser xmlParser = new XmlParser(path);
                parser =(IParse)xmlParser;
            }
            else if (path.EndsWith(".json"))
            {
                parser = new JsonParser(path);
            }
            else
            {
                throw new ArgumentNullException($"invalid extension");
            }
        }

        public T Parse<T>() where T : new()
        {
            return parser.Parse<T>();
        }
        public async Task<T> ParseAsync<T>() where T : new()
        {
            return await Task.Run(() => Parse<T>());
        }
    }
}
