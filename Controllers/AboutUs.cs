using Microsoft.AspNetCore.Mvc;

namespace MVC_ICE_One.Controllers
{
	public class AboutUs : Controller
	{
		public IActionResult Index()
		{
			return View("AboutUs");
		}
	}
}
