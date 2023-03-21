using System.Web.Mvc;

namespace Nhom12_DoAnLapTrinhWeb_QuanLyThueTro.Areas.User
{
    public class UserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "User_default",
                "User/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}