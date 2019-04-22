using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace StringEncrypt
{
    public class StringEncrypt
    {
        private static Encoder encoder = new Encoder();
        private static Decoder decoder = new Decoder();
        public static string Encode(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            bytes = encoder.Encode(bytes);
            return Convert.ToBase64String(bytes);
        }
        public static string Decode(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            bytes = decoder.Decode(bytes);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
