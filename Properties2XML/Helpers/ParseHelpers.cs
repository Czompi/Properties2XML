using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Properties2XML.Helpers
{
    internal static class ParseHelpers
    {
        public static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }


        public static T ParseXml<T>(this string @this) where T : class
        {
            var reader = XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }
        public static void ToFile<T>(this T @this, string fileName) where T : class
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

            System.IO.FileStream file = System.IO.File.Create(fileName);

            writer.Serialize(file, @this);
            file.Close();
        }
        public static string ToString<T>(this T @this) where T : class
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(@this.GetType());
                serializer.Serialize(stringwriter, @this);
                return stringwriter.ToString();
            }
        }

        public static T ParseJson<T>(this string @this) where T : class
        {
            return JsonSerializer.Deserialize<T>(@this.Trim());
        }
    }
}
