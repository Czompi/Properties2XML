using System;
using System.IO;
using System.Text;
using Properties2XML.Helpers;

namespace Properties2XML
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Arguments.Init(ref args);

            var proDir = Arguments.GetParameter("inPath").Replace("/", @"\");
            var xmlDir = Arguments.GetParameter("outPath").Replace("/", @"\");
            var propertyFiles = Directory.GetFiles(Arguments.GetParameter("inPath").Replace("/", @"\"), "*.properties");
            Console.WriteLine($"{string.Join("\r\n", propertyFiles)}");
            foreach (var properties in propertyFiles)
            {

                #region {fileName}.properties file data
                var file = new Props.Properties(properties);
                //Console.WriteLine($"{properties}\r\n{string.Join("\r\n", file)}");
                #endregion

                #region {fileName}.xml file data
                var xmlFile = Xml.Properties.Parse(file);
                var xmlFileName = properties.Replace(proDir, xmlDir).Replace(".properties", ".xml");
                Console.WriteLine($"{xmlFileName}\r\n{xmlFile}");
                File.WriteAllText(xmlFileName, xmlFile.ToString(), Encoding.UTF8);
                #endregion
            }
        }

    }
}
