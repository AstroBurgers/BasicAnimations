// TODO

using System.Xml.Serialization;
using BasicAnimations.Animation_Classes;

namespace BasicAnimations.CustomAnimationsStuff;

[XmlRoot]
public class CustomAnimations
{
    [XmlIgnore]
    internal static CustomAnimations customAnimations;
    
    [XmlElement]
    public Animation customAnimation;
    
    //[XmlAttribute("UserCustomAnimations")]
    public Animation[] CustomAnimationsArray;

    //[XmlAttribute("UserCustomScenarios")]
    public Scenario[] CustomScenariosArray;
    
    public static void DeserializeCustomAnimations()
    {
        var xmlParser = new XmlHelper<CustomAnimations>(@"plugins\BasicAnimations\CustomAnimations.xml");
        customAnimations = xmlParser.DeserializeXml();
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