using Groupon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupon.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            List<Models.GrouponData> Pages = new List<Models.GrouponData>();

            foreach (var item in db.GrouponPages)
            {
                Pages.Add(GetPage(item.Url));
            }


            return View(Pages);
        }

        private GrouponData GetPage(string url)
        {
            GrouponData GD = new GrouponData();

            HtmlAgilityPack.HtmlWeb Html = new HtmlAgilityPack.HtmlWeb();

            var Mobsite = url.Replace("www", "m");
            var doc2 = Html.Load(url);
            try
            {
                GD.TimeRemaining = new TimeSpan(0, 0, 0, 0, int.Parse(doc2.DocumentNode.SelectSingleNode("//input[@class='jcurrentTimeLeft']").Attributes["value"].Value));
           
            }
            catch (Exception)
            {

                GD.TimeRemaining = new TimeSpan(0, 0, 0);
            }
            //GD.TimeRemaining = time.ToString(@"d\ \d\a\y\s\ hh\:mm\:ss");
            var doc = Html.Load(Mobsite);

            GD.URL = url;

            

            try
            {
                GD.Image = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[2]/div[1]/img[1]").Attributes["src"].Value;


                GD.Title = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[2]/h1[1]").InnerText.Trim();

              //  var TimeRemaining = doc.GetElementbyId("time-left");



                var datanodes = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[3]/ul[1]/li");

                GD.Variations = new List<GrouponItem>();

                foreach (var item in datanodes)
                {
                    var tmpitem = new GrouponItem();

                    //var pat = item.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].XPath;
                    //"/html[1]/body[1]/div[3]/ul[1]/li[1]/a[1]/table[1]/tr[1]/td[1]/h3[1]/#text[1]"
                   
                    tmpitem.Title = item.SelectSingleNode(".//tr[1]/td[1]/h3[1]").InnerText;
                    tmpitem.Sold = item.SelectSingleNode(".//tr[1]/td[1]/div[1]/strong[last()]").InnerText;
                    


                    GD.Variations.Add(tmpitem);
                }

                //GD.Sold = doc.GetElementbyId("jDealSoldAmount").InnerText.Trim();

                

                //GD.DealEnds = time.ToString(@"d\ \d\a\y\s\ hh\:mm\:ss");



            }
            catch (Exception)
            {
                //throw;
            }


            return GD;
        }

        private DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
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
