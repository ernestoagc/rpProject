using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace Helper
{
    public static class JsonSerializer
    {
        /// <summary>
        /// Método extensor para serializar un string a JSON
        /// </summary>
        public static string SerializaToJson(this object objeto)
        {
            string jsonResult = string.Empty;
            try
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(objeto.GetType());
                MemoryStream ms = new MemoryStream();
                jsonSerializer.WriteObject(ms, objeto);
                jsonResult = Encoding.Default.GetString(ms.ToArray());
            }
            catch { throw; }
            return jsonResult;
        }
        /// <summary>;
        /// Método extensor para deserializar JSON cualquier objeto
        /// </summary>;
        public static T DeserializarJsonTo<T>(this string jsonSerializado)
        {
            try
            {
                T obj = Activator.CreateInstance<T>();
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonSerializado));
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
                ms.Close();
                ms.Dispose();
                return obj;
            }
            catch { return default(T); }
        }
    }

}
