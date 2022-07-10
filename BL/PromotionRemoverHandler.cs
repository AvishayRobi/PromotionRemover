using System;
using System.Collections.Generic;
using WallaShops.Common.Logs.BL;

namespace PromotionRemover.BL
{
  public class PromotionRemoverHandler
  {   
    public void Exec()
    {
      try
      {
        HashSet<string> promotionIds = getPromotionIds();
        processPromotions(promotionIds);
      }
      catch (Exception ex)
      {
        LogHandler.WriteToConsoleIfDebugMode($"Exception: {ex.Message} \nStackTrace: {ex.StackTrace}");
      }
    }

    private HashSet<string> getPromotionIds()
      =>
      new PromotionRemoverDalManager()
      .GetPromotionIds();

    private void processPromotions(HashSet<string> promotions)
      =>
      new PromotionXmlManager()
      .SetPromotionIds(promotions)
      .ProcessXml()
      .SaveXml();
  }
}
