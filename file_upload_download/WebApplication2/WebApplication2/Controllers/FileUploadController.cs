using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    /// <summary>
    /// ApiController 抽象类和Controller抽象类不能通用
    /// </summary>
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            //return View();
            return null;
        }

        public ActionResult FileUpload()
        {
            //HttpPostedFile file=HttpContext.Current.Request.Files[0];

            return null;
        }
    }
}