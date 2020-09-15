using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public interface ICounter
    {
        ResultWordCount ProcessCounting(string Context, string SearchKeyWords); 
 
    }
}
