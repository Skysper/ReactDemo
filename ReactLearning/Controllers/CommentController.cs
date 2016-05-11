using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactLearning.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Add(string author, string text)
        {
            Models.Comment c = new Models.Comment();
            c.Author = author;
            c.Title = "";
            c.Content = text;
            c.ParentId = 0;
            bool isAdd = DataHelper.Add(c);
            if (isAdd)
            {
                return Json(new { msg = "success", error = 0 });
            }
            else {
                return Json(new { msg = "failed", error = 1 });
            }
        }

        [HttpPost]
        public ActionResult List(string author, string title, string content)
        {
            var result = DataHelper.QueryAll<Models.Comment>();
            return Json(new { msg = "success", error = 0, data = result });
        }

        public ActionResult PagedList(int current, int pageSize)
        {
            var resultTotal = DataHelper.QueryAll<Models.Comment>();
            var result = resultTotal.Skip((current - 1) * pageSize).Take(pageSize).ToList();
            return Json(new { msg = "success", error = 0, list = result, total = resultTotal.Count });
        }

        public ActionResult Delete(int id)
        {
            bool result = DataHelper.Delete<Models.Comment>(id);
            if (result)
            {
                return Json(new { msg = "success", error = 0 });
            }
            else {
                return Json(new { msg = "failed", error = 1 });
            }
        }

    }
}