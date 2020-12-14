﻿using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ParserDll
{
    class XmlParser : IParse
    {
        private readonly string xmlTitle;

        public XmlParser(string xmlTitle)
        {
            this.xmlTitle = xmlTitle;
        }

        public T Parse<T>() where T : new()
        {
            T obj = new T();

            try
            {
                
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (var fs = new FileStream(xmlTitle, FileMode.OpenOrCreate))
                {
                    obj = (T)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }
    }
}