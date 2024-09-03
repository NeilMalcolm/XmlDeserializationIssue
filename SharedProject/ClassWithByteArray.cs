using System.Xml.Serialization;

namespace SharedProject;

public class ClassWithByteArray
{
    //[XmlElement(IsNullable = true)]
    public byte[] FailingProperty { get; set; } 
}