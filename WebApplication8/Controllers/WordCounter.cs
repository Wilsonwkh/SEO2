using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class WordCounter : ICounter
    {
   
        public ResultWordCount ProcessCounting(string Context, string SearchKeyWords)
        {
            List<WordCount> _wordcount = new List<WordCount>();
            ResultWordCount result = new ResultWordCount();
                        
            string[] _context = Context.Split(' '); //split each word in context to list
            _context = _context.Distinct().ToArray(); //Apply distinct in array to remove duplicates.

            //search each word in context and add count into wordcount
            foreach (string word in _context)
            {
                int _count = new int();
                //var rx = new Regex(word, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var rx = new Regex(word, RegexOptions.Compiled);
                Match match = rx.Match(Context);
                while (match.Success)
                {
                    _count += 1;
                    match = match.NextMatch();
                }
                _wordcount.Add(new WordCount { Word = word, Count = _count });
            }
            result.Output_Result = _wordcount;

            return result;

        }
    }
}