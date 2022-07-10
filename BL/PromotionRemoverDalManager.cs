using System.Collections.Generic;
using System.Data;
using System.Linq;
using PromotionRemover.DAL;
using WallaShops.Utils;

namespace PromotionRemover.BL
{
  public class PromotionRemoverDalManager
  {
    #region Data Members
    private PromotionRemoverDal dal { get; }
    #endregion

    #region Ctor
    public PromotionRemoverDalManager()
    {
      this.dal = new PromotionRemoverDal();
    }
    #endregion

    public HashSet<string> GetPromotionIds()
    {
      DataTable dt = this.dal.GetPromotionIds();

      return dt
        .AsEnumerable()
        .Select(toRowCollection)
        .ToHashSet<string>();
    }

    private string toRowCollection(DataRow dr)
      =>
      dr.Field<string>("promotion_id");
  }
}
