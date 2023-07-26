using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentACar.Models;

namespace RentACar.Controllers
{
    public class AdminController : Controller
    {
        DataContex _db;

        public AdminController(DataContex db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Marka
        public IActionResult MarkaListe()
        {
            return View(_db.TBL_MARKA.ToList());
        }
        [HttpGet]
        public IActionResult MarkaForm(int? id)
        {
            
            var marka = new TBL_MARKA();
            if (id != null)
            {
                marka = _db.TBL_MARKA.Find(id);
            }
            return View(marka);
        }
        [HttpPost]
        public async Task<IActionResult> MarkaForm(IFormFile uploadedFile, TBL_MARKA model)
        {
            if (uploadedFile != null)
            {
                string imageExtension = Path.GetExtension(uploadedFile.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await uploadedFile.CopyToAsync(stream);
                model.ICON = "/img/" + imageName;
            }
            if (model.ID > 0)
            {
                _db.ChangeTracker.Clear();
                _db.TBL_MARKA.Update(model);
                _db.SaveChanges();
            }
            else
            {
                _db.TBL_MARKA.Add(model);
                _db.SaveChanges();
            }

            return RedirectToAction("MarkaListe");
        }
        public IActionResult MarkaSil(int? id)
        {
              _db.TBL_MARKA.Remove(_db.TBL_MARKA.Find(id));
                _db.SaveChanges();
            
            return RedirectToAction("MarkaListe"); 
        }
        #endregion
        #region AracBilgi
        public IActionResult AracListe()
        {
            return View(_db.TBL_ARAC.ToList());
        }
        [HttpGet]
        public IActionResult AracForm(int? id)
        {

            ViewBag.aracSelect = _db.TBL_MARKA.Select(m => new SelectListItem { Value = m.ID.ToString(), Text = m.MARKA }).ToList();
            ViewBag.ilselect = _db.ILLER.Select(m => new SelectListItem { Value = m.ID.ToString(), Text = m.SEHIR_AD }).ToList();
            var arac = new TBL_ARAC();
            if(id != 0)
            {
                arac = _db.TBL_ARAC.Find(id);
            }
            return View(arac);
        }
        [HttpPost]
        public async Task<IActionResult> AracForm(IFormFile uploadedFile, TBL_ARAC model)
        {
            if (uploadedFile != null)
            {
                string imageExtension = Path.GetExtension(uploadedFile.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await uploadedFile.CopyToAsync(stream);
                model.GORSEL = "/img/" + imageName;
            }
            if (model.ID > 0)
            {
                _db.ChangeTracker.Clear();
                _db.TBL_ARAC.Update(model);
                _db.SaveChanges();

            }
            else
            {
     

                _db.TBL_ARAC.Add(model);
                _db.SaveChanges();
            }
            return RedirectToAction("AracListe");
        }
        public IActionResult AracSil(int? id)
        {
     
            
                _db.TBL_ARAC.Remove(_db.TBL_ARAC.Find(id));
                _db.SaveChanges();
            
            return RedirectToAction("AracListe");
        }
        #endregion
    }

}
