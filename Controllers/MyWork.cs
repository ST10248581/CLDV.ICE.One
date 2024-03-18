using Microsoft.AspNetCore.Mvc;

namespace MVC_ICE_One.Controllers
{
	public class MyWork : Controller
	{
		public IActionResult Index()
		{
			return View("MyWork");
		}
	}
}
