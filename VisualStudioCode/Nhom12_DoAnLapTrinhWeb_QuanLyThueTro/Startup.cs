using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nhom12_DoAnLapTrinhWeb_QuanLyThueTro.Startup))]
namespace Nhom12_DoAnLapTrinhWeb_QuanLyThueTro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
