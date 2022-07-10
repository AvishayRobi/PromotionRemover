using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PromotionRemover.XML
{
  public class XmlSaver
  {
    #region Data Members
    private IEnumerable<XElement> xml { get; set; }
    private XElement xmlWithRootTag { get; set; }
    private string fullPathToSave { get; set; }
    private XNamespace nameSpace { get; set; }
    #endregion

    #region Ctor
    public XmlSaver()
    {
      this.xmlWithRootTag = new XElement("Root");
      this.xml = Enumerable.Empty<XElement>();
      this.fullPathToSave = string.Empty;
      this.nameSpace = string.Empty;
    }
    #endregion

    public XmlSaver SetXmlContent(IEnumerable<XElement> xml)
    {
      this.xml = xml;

      return this;
    }

    public XmlSaver SetFullPath(string fullPath)
    {
      this.fullPathToSave = fullPath;

      return this;
    }

    public XmlSaver ApplyCustomNamespace(string nameSpace)
    {
      this.nameSpace = nameSpace;

      return this;
    }

    public XmlSaver ApplyCustomRootTag(string customRootTag = "promotions")
    {
      this.xmlWithRootTag = new XElement(this.nameSpace + customRootTag, this.xml);

      return this;
    }

    public void Save()
      =>
      new XDocument(this.xmlWithRootTag)
      .Save(this.fullPathToSave);
  }
}
