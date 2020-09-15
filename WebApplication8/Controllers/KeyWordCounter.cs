using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class KeyWordCounter : ICounter

    {
      
        public ResultWordCount ProcessCounting(string Context, string SearchKeyWords)
        {

            List<WordCount> _wordcount = new List<WordCount>();
            ResultWordCount result = new ResultWordCount();

            //split each word in context to list
            string[] _context = SearchKeyWords.Split(',');

            //search each word in context and add count into wordcount
            foreach (string word in _context)
            {
                int _count = new int();
                var rx = new Regex(word, RegexOptions.Compiled | RegexOptions.IgnoreCase);
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