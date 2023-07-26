using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RentACar.Models;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        DataContex _c;

        public HomeController(DataContex c)
        {
            _c = c;
        }

  
        public IActionResult Index()
        {
            
            var model = _c.RentView.ToList();
            ViewBag.datas = _c.TBL_MARKA.Where(x => model.Select(m => m.MARKA_ID).Contains(x.ID)).ToList(); 
            return View(model);
        }

       

    }
}