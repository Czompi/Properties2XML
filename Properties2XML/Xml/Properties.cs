using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Properties2XML.Helpers;

namespace Properties2XML.Xml
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, TypeName = "Properties")]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Properties
    {
        public static Properties Parse(Props.Properties props)
        {
            Properties file = new();
            file.Property = new();
            foreach (var prop in props)
            {
                file.Property.Add(new() { Name = prop.Key.Trim(), Value = prop.Value.Trim() });
            }

            return file;
        }

        public override string ToString() => this.ToString<Properties>();

        [XmlElement("Property")]
        public List<Property> Property { get; set; }
    }
}