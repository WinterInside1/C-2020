using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIgBroatherFinal
{
    class Manager
    {
        private readonly IParse parser;
        public Manager(string path)
        {
            if (Path.GetExtension(path) == ".xml")
            {
                parser = new XmlParser(path);
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
