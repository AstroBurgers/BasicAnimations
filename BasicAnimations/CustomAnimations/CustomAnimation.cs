using System.Xml.Serialization;
using BasicAnimations.AnimationClasses;

namespace BasicAnimations.CustomAnimations;

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
        CustomAnimationsArray = animations;
        CustomScenariosArray = scenarios;
    }
}

[XmlType("Item")]
public class CustomAnimation
{
    
}