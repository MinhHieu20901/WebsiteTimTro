using System.Web;
using System.Web.Mvc;

namespace Nhom12_DoAnLapTrinhWeb_QuanLyThueTro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
