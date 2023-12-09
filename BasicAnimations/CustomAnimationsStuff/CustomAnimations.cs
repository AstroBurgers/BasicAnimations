// TODO

using System.Xml.Serialization;
using BasicAnimations.Animation_Classes;

namespace BasicAnimations.CustomAnimationsStuff;

public class CustomAnimations
{
    internal static CustomAnimations _customAnimations;
    
    [XmlAttribute("CustomAnimations")]
    internal Animation[] customAnimationsArray;

    [XmlAttribute("CustomScenarios")]
    internal Scenario[] customScenariosArray;
    
    public static void DeserializeCustomAnimations()
    {
        var xmlParser = new XMLHelper<CustomAnimations>(@"plugins\BasicAnimations\CustomAnimations.xml");
        _customAnimations = xmlParser.DeserializeXML();
    }


    public CustomAnimations() {  }

    public CustomAnimations(Animation[] animations, Scenario[] scenarios)
    {
        this.customAnimationsArray = animations;
        this.customScenariosArray = scenarios;
    }
}