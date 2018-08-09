using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ForensicsCourseToolkit.Framework_Project.Serialization
{
    public static class SerializationHelper
    {
        public static T DeserializeXML<T>(this string toDeserialize)
        {

            //used before XML serialize but there was an issue with compression
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader textReader = new StringReader(toDeserialize);
            return (T)xmlSerializer.Deserialize(textReader);
        }

        public static T Deserialize<T>(this string toDeserialize)
        {
            byte[] b = Convert.FromBase64String(toDeserialize);
            using (var stream = new MemoryStream(b))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }

        }

        public static string SerializeXML<T>(this T toSerialize)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Encoding = new UnicodeEncoding(false, false), // no BOM in a .NET string
                Indent = false,
                OmitXmlDeclaration = false
            };


            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }

        public static string Serialize<T>(this T toSerialize)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, toSerialize);
                stream.Flush();
                stream.Position = 0;
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
