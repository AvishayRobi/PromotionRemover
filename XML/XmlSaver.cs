using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PromotionRemover.Model;

namespace PromotionRemover.XML
{
  public class XmlSaver
  {
    #region Data Members
    private IEnumerable<XElement> xml { get; set; }
    private XElement xmlWithRootTag { get; set; }
    private XmlInfo xmlInfo { get; }
    #endregion

    #region Ctor
    public XmlSaver(XmlInfo xmlInfo)
    {
      this.xmlWithRootTag = new XElement("Root");
      this.xml = Enumerable.Empty<XElement>();
      this.xmlInfo = xmlInfo;
    }
    #endregion

    public XmlSaver SetXmlContent(IEnumerable<XElement> xml)
    {
      this.xml = xml;

      return this;
    }

    public XmlSaver ApplyCustomRootTag(string customRootTag = "promotions")
    {
      XNamespace ns = this.xmlInfo.Namespace;
      this.xmlWithRootTag = new XElement(ns + customRootTag, this.xml);

      return this;
    }

    public void Save()
      =>
      new XDocument(this.xmlWithRootTag)
      .Save(this.xmlInfo.SaveFullPath);
  }
}
