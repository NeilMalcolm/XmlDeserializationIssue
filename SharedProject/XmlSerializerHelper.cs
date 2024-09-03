using System.Xml.Serialization;

namespace SharedProject;

public static class XmlSerializerHelper
{
    /// <summary>
    /// Gets the object from XML string.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="xmlString">The XML string.</param>
    /// <returns></returns>
    public static T? Deserialize<T>(string xmlString)
    {
        using var textReader = new StringReader(xmlString);
        return (T?)GetXmlSerializer<T>().Deserialize(textReader);
    }

    public static string Serialize<T>(T objectToSerialize)
    {
        var serializer = GetXmlSerializer<T>();
        using var textWriter = new StringWriter();
        serializer.Serialize(textWriter, objectToSerialize);

        return textWriter.ToString();
    }

    private static XmlSerializer GetXmlSerializer<T>()
    {
        return new XmlSerializer(typeof(T));
    }
}