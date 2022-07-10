using PromotionRemover.BL;

namespace PromotionRemover
{
  public class Program
  {
    public static void Main(string[] args)
    {
      PromotionRemoverHandler handler = new PromotionRemoverHandler();

      handler.Exec();
    }
  }
}
