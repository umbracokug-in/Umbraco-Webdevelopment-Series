using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Components
{
    [ViewComponent(Name = "Navigation")]
    public class NavigationComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
