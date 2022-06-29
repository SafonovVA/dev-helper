using System.Text;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace DevHelper.Controllers; 

public class UnicodeController : Controller  {
    public IActionResult Index()
    {
        return View();
    }

    public JsonResult Convert(string? from, string type)
    {
        if (from == null){
            return new JsonResult(null);
        }
        var unicode = Encoding.Unicode;
        var utf8 = Encoding.UTF8;
        
        byte[] bytes;
        if (type == "decode") {
            from = HttpUtility.UrlDecode(from, utf8);
            //from = "\u0633\u0637\u0648\u0631 \u0639\u0628\u0631 \u0627\u0644\u0623\u064a\u0627\u0645";
            Console.WriteLine(from);
            bytes = Encoding.Convert(unicode, utf8, unicode.GetBytes(from));
            var result = utf8.GetString(bytes);
            Console.WriteLine(result);
            return Json(utf8.GetString(bytes));
        }
        else
        {
             bytes = Encoding.Convert(utf8, unicode, utf8.GetBytes(from));
        }
        
        
        var sb = new StringBuilder();
        foreach(var b in bytes) {
            sb.Append(b);
        }
        
        return Json(sb.ToString());
    }
/*
 * \u0633\u0637\u0648\u0631 \u0639\u0628\u0631 \u0627\u0644\u0623\u064a\u0627\u0645 1
 * text \u0645
 */
}