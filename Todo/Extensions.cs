using System;
using Newtonsoft.Json;

namespace Extensions
{
    public class DecodingExtensions
    {
        public static T DecodeObject<T>(string json)
        {
            var objects = JsonConvert.DeserializeObject<T>(json);
            return objects;
        }
    }
}
