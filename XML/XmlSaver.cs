using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PromotionRemover.Model;
using PromotionRemover.XML;
using WallaShops.Utils;

namespace PromotionRemover.BL
{
  public class PromotionXmlManager
  {
    #region Data Members
    private IEnumerable<XElement> parsedXml { get; set; }
    private HashSet<string> promotionIds { get; set; }
    private XmlInfo xmlInfo { get; }
    #endregion

    #region Ctor
    public PromotionXmlManager()
    {
      this.parsedXml = Enumerable.Empty<XElement>();
      this.promotionIds = new HashSet<string>();
      this.xmlInfo = getXmlInfo();
    }
    #endregion

    public PromotionXmlManager SetPromotionIds(HashSet<string> promotionIds)
    {
      this.promotionIds = promotionIds;

      return this;
    }

    public PromotionXmlManager ProcessXml()
    {
      IEnumerable<XElement> xml = getXml();
      this.parsedXml = disableOfflinePromotions(xml);

      return this;
    }

    public void SaveXml()
      =>
      new XmlSaver(this.xmlInfo)
      .SetXmlContent(this.parsedXml)
      .ApplyCustomRootTag()
      .Save();

    private IEnumerable<XElement> getXml()
      =>
      new XmlFetcher()
      .SetFullPath(this.xmlInfo.FetchFullPath)
      .GetPromotionsXml();

    private IEnumerable<XElement> disableOfflinePromotions(IEnumerable<XElement> xml)
      =>
      new XmlParser()
      .SetPromotionIds(this.promotionIds)
      .SetXml(xml)
      .SetXmlNamespace(this.xmlInfo.Namespace)
      .DisablePromotions();

    private XmlInfo getXmlInfo()
      =>
      new XmlInfo()
      {
        FetchFullPath = WSGeneralUtils.GetAppSettings("XmlFullPath"),
        SaveFullPath = WSGeneralUtils.GetAppSettings("SaveFullPath"),
        Namespace = WSGeneralUtils.GetAppSettings("XmlNamespace")
      };
  }
}
