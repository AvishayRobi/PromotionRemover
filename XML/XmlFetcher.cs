using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace PromotionRemover.XML
{
  public class XmlFetcher
  {
    #region Data Members
    private string fullPath { get; set; }
    #endregion

    #region Ctor
    public XmlFetcher()
    {
      this.fullPath = string.Empty;
    }
    #endregion

    public XmlFetcher SetFullPath(string fullPath)
    {
      this.fullPath = fullPath;

      return this;
    }

    public IEnumerable<XElement> GetPromotionsXml()
    {
      string fileContent = getFileContent();
      string cleanedFileContent = cleanFileContent(fileContent);
      XDocument xml = XDocument.Parse(cleanedFileContent);

      return getPromotions(xml);
    }

    private string cleanFileContent(string fileContent)
      =>
      fileContent
      .Replace("&#55356;", string.Empty)
      .Replace("&#57217;", string.Empty);

    private string getFileContent()
      =>
      FileManager.GetFileText(this.fullPath);

    private IEnumerable<XElement> getPromotions(XDocument xml)
      =>
      xml
      .Elements()
      .Elements();
  }
}
