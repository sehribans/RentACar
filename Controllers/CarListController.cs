using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models;

namespace RentACar.Controllers
{
    
    public class CarListController : Controller
    {
        DataContex _c;

        public CarListController(DataContex c)
        {
            _c = c;
        }

        public IActionResult Index(string[]? Filtreler)
        {
            ViewBag.datas = _c.TBL_MARKA.ToList();
            if (Filtreler.Length > 0)
            {
                return View(_c.RentView.Where(m => Filtreler.Contains(m.MARKA)).ToList());

            }
            else
            {
            return View(_c.RentView.ToList());

            }

        }

    }
}
