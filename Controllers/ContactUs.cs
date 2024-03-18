using Microsoft.AspNetCore.Mvc;

namespace MVC_ICE_One.Controllers
{
	public class ContactUs : Controller
	{
		public IActionResult Index()
		{
			return View("ContactUs");
		}
	}
}
