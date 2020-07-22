using EinTech.Test.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EinTech.Test.Web.UnitTests.Controllers
{
    public class HomeControllerTests
    {
        private readonly HomeController _homeController;

        public HomeControllerTests()
            => _homeController = new HomeController();

        [Fact]
        public void CanGetIndex()
        {
            IActionResult result = _homeController.Index();

            ViewResult view = Assert.IsType<ViewResult>(result);

            Assert.Null(view.ViewName);
        }
    }
}
