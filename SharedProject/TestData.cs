using System.Xml.Serialization;

namespace SharedProject;

public static class TestData
{
    public static void PerformTest()
    {
        var firstItem = ExampleWithListProperty;
        var secondItem = ExampleMissingListProperty;

        // serialize first item (with list property)
       var firstItemSerialized = XmlSerializerHelper.Serialize(firstItem);
        
        // deserialize 
        var firstItemDeserialized = XmlSerializerHelper.Deserialize<OuterClass>(firstItemSerialized);

        LogResult(firstItemDeserialized, firstItemSerialized); 
        
        // serialize second item (with no list property)
        var secondItemSerialized = XmlSerializerHelper.Serialize(secondItem);
        // deserialize 
        var secondItemDeserialized = XmlSerializerHelper.Deserialize<OuterClass>(secondItemSerialized);

        // here secondItemDeserialized.Items == null only on iOS
        LogResult(secondItemDeserialized, secondItemSerialized);
        ConfirmIfNull(secondItemDeserialized.Items);
    }

    public static void PerformByteArrayTest()
    {
        var instance = new ClassWithByteArray();
        
        // iOS does not like this
        instance.FailingProperty = null;
        
        XmlSerializerHelper.Serialize(instance);
    }

    private static void ConfirmIfNull(List<InnerItem>? items)
    {
        _ = items ?? throw new Exception("Deserialized property is null!");
    }

    private static OuterClass ExampleMissingListProperty
        => new()
        {
            Text = "Missing"
        };
    
    private static OuterClass ExampleWithListProperty
        => new()
        {
            Text = "With",
            Items =
            [
                new InnerItem
                {
                    Text = "First child"
                }
            ]
        };

    private static void LogResult(OuterClass result, string xml)
    {
        Console.WriteLine($"Deserialized item '{result.Text}'!{Environment.NewLine}XML: ({xml}){Environment.NewLine} has {result?.Items?.Count ?? -1} items.");
        
        if (result?.Items is null)
        {
            Console.WriteLine("Items List is null!");
        }
        
        Console.WriteLine(Environment.NewLine);
    }
}