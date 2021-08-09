using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Properties2XML.Xml
{

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class Property
    {
        [XmlAttribute()]
        public string Name { get; set; }

        [XmlText()]
        public string Value { get; set; }
    }
}