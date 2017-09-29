using Agatha.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P202.Training.WCF.RequestsAndResponses;
using System.Reflection;

namespace P202.Training.MVC.Controllers
{
    public class P202Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TestAgatha()
        {
            IRequestDispatcher requestDispatcher = null;
            try
            {
                requestDispatcher =   Agatha.Common.InversionOfControl.IoC.Container.Resolve<IRequestDispatcher>();

                requestDispatcher.Clear();
                requestDispatcher.Add(new ListUsersRequest());

                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                result.Data = requestDispatcher.Get<ListUsersResponse>().UserList;
                return result;

            }
            finally
            {
                if (requestDispatcher != null)
                {
                    Agatha.Common.InversionOfControl.IoC.Container.Release(requestDispatcher);
                }
            }
        }
    }
}