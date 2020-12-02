using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace BIgBroatherFinal
{  
        class JsonParser : IParse
        {
            private readonly string jsonTitle;

            public JsonParser(string jsonTitle)
            {
                this.jsonTitle = jsonTitle;
            }

            public T Parse<T>() where T : new()
            {
                T obj = new T();

                try
                {
                    string jsonString = File.ReadAllText(jsonTitle);
                    obj = JsonSerializer.Deserialize<T>(jsonString);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return obj;
            }
        }
    
}
