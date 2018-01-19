using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationGenerateConfigDLLTest;

namespace WebApplicationGenerateConfigTest.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			string str = "a";
			//#if DEBUG
			//			str = "DEBUG";
			//#elif ONLINE
			//			str = "ONLINE";
			//#else
			//			str = "RELEASE";
			//#endif

			str = ConfigTest.GetStr();
			return Content(str);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}