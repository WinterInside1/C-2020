using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;

namespace ParserDll
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
        public async Task<T> ParseAsync<T>() where T : new()
        {
            return await Task.Run(() => Parse<T>());
        }
    }
}
