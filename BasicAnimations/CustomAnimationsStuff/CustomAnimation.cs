// TODO

using System.Xml.Serialization;
using BasicAnimations.Animation_Classes;

namespace BasicAnimations.CustomAnimationsStuff;

[XmlRoot]
public class CustomAnimations
{
    internal static CustomAnimation customAnimations;

    [XmlElement]
    internal CustomAnimation customAnimation;
    
    [XmlAttribute("CustomAnimations")]
    internal Animation[] CustomAnimationsArray;

    [XmlAttribute("CustomScenarios")]
    internal Scenario[] CustomScenariosArray;
    
    public static void DeserializeCustomAnimations()
    {
        var xmlParser = new XmlHelper<CustomAnimation>(@"plugins\BasicAnimations\CustomAnimations.xml");
        CustomAnimations = xmlParser.DeserializeXml();
    }


    public CustomAnimations() {  }

    public CustomAnimations(Animation[] animations, Scenario[] scenarios)
    {
        this.CustomAnimationsArray = animations;
        this.CustomScenariosArray = scenarios;
    }
}

[XmlType("Item")]
public class CustomAnimation
{
    
}