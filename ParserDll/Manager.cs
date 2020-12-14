using System.IO;


namespace ParserDll
{
   public class Manager
    {
        private readonly IParse parser;
        public Manager(string path)
        {
            if (Path.GetExtension(path) == ".xml")
            {
                XmlParser xmlParser = new XmlParser(path);
                parser =(IParse)xmlParser;
            }
            else if (Path.GetExtension(path) == ".json")
            {
                parser = new JsonParser(path);
            }
        }

        public T Parse<T>() where T : new()
        {
            return parser.Parse<T>();
        }
    }
}
