using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PromotionRemover.XML
{
  public class XmlParser
  {
    #region Data Members
    private HashSet<string> promotionIds { get; set; }
    private IEnumerable<XElement> xml { get; set; }
    private XNamespace nameSpace { get; set; }
    #endregion

    #region Ctor
    public XmlParser()
    {
      this.promotionIds = new HashSet<string>();
      this.xml = Enumerable.Empty<XElement>();
      this.nameSpace = string.Empty;
    }
    #endregion

    public XmlParser SetPromotionIds(HashSet<string> promotionIds)
    {
      this.promotionIds = promotionIds;

      return this;
    }

    public XmlParser SetXml(IEnumerable<XElement> xml)
    {
      this.xml = xml;

      return this;
    }

    public XmlParser SetXmlNamespace(string nameSpace)
    {
      this.nameSpace = nameSpace;

      return this;
    }

    public IEnumerable<XElement> DisablePromotions()      
      => 
      this.xml
      .Where(isPromotionToDelete)
      .Select(disablePromotion);

    private bool isPromotionToDelete(XElement xElement)
      =>
      this.promotionIds.Contains(xElement.Attribute("promotion-id")?.Value) 
      || this.promotionIds.Contains(xElement.Attribute("campaign-id")?.Value);

    private XElement disablePromotion(XElement xElement)
    {
      xElement.SetElementValue("enabled-flag", "false");

      return xElement;
    }
  }
}
