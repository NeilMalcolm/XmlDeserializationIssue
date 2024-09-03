using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SharedProject;

public class OuterClass
{
    [XmlAttribute("name")]
    public string Text { get; set; }

    [XmlElement("item")]
    public List<InnerItem> Items { get; set; }
}
 
public class InnerItem
{
    [XmlAttribute("text")]
    public string Text { get; set; }
}

