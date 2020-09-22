using Log.Abstractions;
using Newtonsoft.Json;

namespace Log.Services
{
    public class DefaultSerializer : ISerializer
    {
        
        public T Deserialize<T>(string val) =>
            string.IsNullOrWhiteSpace(val)
            ? default(T)
            : JsonConvert.DeserializeObject<T>(val);

        public string Serialize<T>(T val) =>
            (val == null)
            ? ""
            : JsonConvert.SerializeObject(val);        
    }
}