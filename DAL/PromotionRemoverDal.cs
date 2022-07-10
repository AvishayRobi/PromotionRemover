using System.Data;
using WallaShops.Data;
using WallaShops.Objects;

namespace PromotionRemover.DAL
{
  public class PromotionRemoverDal : WSSqlHelper
  {
    #region Ctor
    public PromotionRemoverDal() : base(WSPlatforms.WallaShops)
    {
    }
    #endregion

    public DataTable GetPromotionIds()
      =>
      GetDataTable("promotion_remover_get_promotion_ids");
  }
}
