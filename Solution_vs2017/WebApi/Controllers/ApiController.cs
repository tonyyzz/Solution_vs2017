using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
	public class ApiController : Controller
	{
		// GET: Api
		public ActionResult list()
		{
			string pageStr = Request["page"] ?? "";
			int page = 0;
			int.TryParse(pageStr, out page);
			if (page <= 0)
			{
				page = 1;
			}

			int pageSize = 10;
			int totalCount = GetList().Count();
			int pageCount = Convert.ToInt32(Math.Ceiling(totalCount * 1.0 / pageSize));

			var data = GetList().Skip(pageSize * (page - 1)).Take(pageSize).ToList();
			return Json(new { data = data, pages = pageCount }, JsonRequestBehavior.AllowGet);


		}

		public List<int> GetList()
		{
			List<int> list = new List<int>();
			for (int i = 1; i <= 100; i++)
			{
				list.Add(i);
			}
			return list;
		}
	}
}