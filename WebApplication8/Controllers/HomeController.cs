using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
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

        public ActionResult WordCount(FormCollection collection)
        {
            ViewBag.Message = "Your Word Count page.";
            ICounter _counter;

            //Get input from view            
            ResultWordCount result = new ResultWordCount();
            InputWordCount inputWordCount = new InputWordCount
            {
                Input_SearchContext = Convert.ToString(collection["Context"]),
                Input_SearchKeyWords = Convert.ToString(collection["SearchKeyWords"])
            };
            // --------------------

            if (!string.IsNullOrEmpty(inputWordCount.Input_SearchContext)) //If Context is there, perform search. Otherwise, return empty search result
            {                
                if (string.IsNullOrEmpty(inputWordCount.Input_SearchKeyWords)) //if Search keyword is not specify, perform counting for each word in context. Otherwise, count based on keywords. 
                {
                    _counter = new WordCounter();
                }
                else
                {
                    _counter = new KeyWordCounter();
                }

                result = _counter.ProcessCounting(inputWordCount.Input_SearchContext, inputWordCount.Input_SearchKeyWords); //Set output to View 

                Session["result"] = result; //put result in session to ensure result kept in webgrid for sorting. 
            }
            else
            {
                if ((ResultWordCount)Session["result"] == null)
                {
                    List<WordCount> _result = new List<WordCount>();
                    _result.Add(new WordCount { Word = "", Count = 0 });
                    result.Output_Result = _result;
                }
                else
                {
                    result = (ResultWordCount)Session["result"]; //get result from session to ensure result kept in webgrid for sorting. 
                }
            }
                        
            return View(result);
         }
    }
}