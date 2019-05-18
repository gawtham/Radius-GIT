using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Radius.Core;
using Radius.Core.SearchService;
using Radius.UI.Models;
using Radius.UI.Utils;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Radius.UI.Controllers
{
    public class StatusController : Controller
    {
        /// <summary>
        /// Deafult landing page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// geneates a JSON of queries which Application layer uses to make GET requests
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowCrossSiteJson]
        public ActionResult GitTableSettings()
        {
            var res = ReadData();
            var settings = new GitSearchSettings(res);
            var model = new GitSearchModel()
            {
                toalIssueCountQuery = settings.ToalIssueCountQuery(),
                issuesCountInLast24HrsQuery = settings.AfterQuery(DateTime.Now.AddDays(-1)),
                issuesCountBtwn24HrsTo7DaysQuery  = settings.BetweenQuery(DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-1)),
                issuesCountAfter7DaysQuery = settings.BeforeQuery(DateTime.Now.AddDays(-7))
            };
            return Json(model);
        }

        /// <summary>
        /// Read the Post data sent from the UI
        /// </summary>
        /// <returns></returns>
        private string ReadData()
        {
            var stream = Request.InputStream;
            stream.Seek(0, SeekOrigin.Begin);
            var readStream = new StreamReader(stream, Encoding.UTF8);
            var json = readStream.ReadToEnd();
            var resp = JsonConvert.DeserializeObject<string>(json);
            return resp;
        }
    }
}