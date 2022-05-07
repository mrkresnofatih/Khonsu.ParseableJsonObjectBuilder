using System.IO;
using Newtonsoft.Json;

namespace Khonsu.ParseableJsonObjectBuilder
{
    public class ParseableJsonObjectBuilder<T> : IParseableJsonObjectBuilder<T>
    {
        private string _jsonPath;
        
        public IParseableJsonObjectBuilder<T> SetJsonPath(string jsonPath)
        {
            _jsonPath = "../../../" + jsonPath;
            return this;
        }

        public T Build()
        {
            var streamReader = new StreamReader(_jsonPath);
            var json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
