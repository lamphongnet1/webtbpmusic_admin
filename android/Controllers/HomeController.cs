using android.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace android.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicappContext db = new MusicappContext();
        [ApiController]
        [Route("api/[controller]")]
        public class ExampleController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(new { Message = "Hello, Swagger!" });
            }
        }
        // Trang chủ
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        // Danh sách danh mục
        [Route("DanhMuc")]
        public IActionResult DanhMuc()
        {
            var lstDanhMuc = db.Danhmucs.ToList();
            return View(lstDanhMuc);
        }

        // Thêm danh mục mới - GET
        [Route("ThemDanhMucMoi")]
        [HttpGet]
        public IActionResult ThemDanhMucMoi()
        {
            return View();
        }

        // Thêm danh mục mới - POST
        [Route("ThemDanhMucMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemDanhMucMoi(Danhmuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Danhmucs.Add(danhMuc);
                    db.SaveChanges();
                    return RedirectToAction("DanhMuc");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Có lỗi khi thêm danh mục: " + ex.Message);
                }
            }
            return View();
        }

        // Sửa danh mục - GET
        [Route("SuaDanhMuc/{idDanhMuc}")]
        [HttpGet]
        public IActionResult SuaDanhMuc(int idDanhMuc)
        {
            var danhMuc = db.Danhmucs.FirstOrDefault(d => d.IdDanhMuc == idDanhMuc);
            if (danhMuc == null)
            {
                return NotFound();
            }

            return View(danhMuc);
        }

        // Sửa danh mục - POST
        [Route("SuaDanhMuc/{idDanhMuc}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaDanhMuc(int idDanhMuc, Danhmuc danhMuc)
        {
            if (idDanhMuc != danhMuc.IdDanhMuc)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(danhMuc).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DanhMuc");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Có lỗi khi sửa danh mục: " + ex.Message);
                }
            }

            return View(danhMuc);
        }

        // Xóa danh mục - GET
        [Route("XoaDanhMuc/{idDanhMuc}")]
        [HttpGet]
        public IActionResult XoaDanhMuc(int idDanhMuc)
        {
            var danhMuc = db.Danhmucs.FirstOrDefault(d => d.IdDanhMuc == idDanhMuc);
            if (danhMuc == null)
            {
                return NotFound();
            }

            return View(danhMuc);
        }

        // Xóa danh mục - POST
        [Route("XoaDanhMuc/{idDanhMuc}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaDanhMuc(int idDanhMuc, IFormCollection form)
        {
            var danhMuc = db.Danhmucs.FirstOrDefault(d => d.IdDanhMuc == idDanhMuc);
            if (danhMuc == null)
            {
                return NotFound();
            }

            try
            {
                db.Danhmucs.Remove(danhMuc);
                db.SaveChanges();
                return RedirectToAction("DanhMuc");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Có lỗi khi xóa danh mục: " + ex.Message);
            }

            return View(danhMuc);
        }

        // Danh sách bài hát
        [Route("BaiHat")]
        public IActionResult BaiHat()
        {
            var lstDanhMuc = db.Baihats.ToList();
            return View(lstDanhMuc);
        }

        // Danh sách bài hát
        [Route("NgheSi")]
        public IActionResult NgheSi()
        {
            var lstDanhMuc = db.Nghesis.ToList();
            return View(lstDanhMuc);
        }
        // Thêm bài hát mới - GET
        [Route("ThemBaiHatMoi")]
        [HttpGet]
        public IActionResult ThemBaiHatMoi()
        {
            // Cung cấp danh mục và nghệ sĩ cho dropdown
            ViewBag.DanhMuc = new SelectList(db.Danhmucs.ToList(), "IdDanhMuc", "TenDanhMuc");
            ViewBag.IdNgheSi = new SelectList(db.Nghesis.ToList(), "IdNgheSi", "TenNgheSi");
            return View();
        }

        // Thêm bài hát mới - POST
        [Route("ThemBaiHatMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemBaiHatMoi(Baihat baiHat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Baihats.Add(baiHat);
                    db.SaveChanges();
                    return RedirectToAction("BaiHat");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Có lỗi khi thêm bài hát: " + ex.Message);
                }
            }
            // Cung cấp lại dropdown trong trường hợp có lỗi
            ViewBag.DanhMuc = new SelectList(db.Danhmucs.ToList(), "IdDanhMuc", "TenDanhMuc");
            ViewBag.NgheSi = new SelectList(db.Nghesis.ToList(), "IdNgheSi", "TenNgheSi");
            return View();
        }

        // Sửa bài hát - GET
        [Route("SuaBaiHat/{idBaiHat}")]
        [HttpGet]
        public IActionResult SuaBaiHat(int idBaiHat)
        {
            var baiHat = db.Baihats.FirstOrDefault(b => b.IdBaiHat == idBaiHat);
            if (baiHat == null)
            {
                return NotFound();
            }

            // Cung cấp danh mục và nghệ sĩ cho dropdown
            ViewBag.DanhMuc = new SelectList(db.Danhmucs.ToList(), "IdDanhMuc", "TenDanhMuc", baiHat.IdDanhMuc);
            ViewBag.NgheSi = new SelectList(db.Nghesis.ToList(), "IdNgheSi", "TenNgheSi", baiHat.IdNgheSi);
            return View(baiHat);
        }

        // Sửa bài hát - POST
        [Route("SuaBaiHat/{idBaiHat}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaBaiHat(int idBaiHat, Baihat baiHat)
        {
            if (idBaiHat != baiHat.IdBaiHat)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(baiHat).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("BaiHat");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Có lỗi khi sửa bài hát: " + ex.Message);
                }
            }

            // Cung cấp lại dropdown trong trường hợp có lỗi
            ViewBag.DanhMuc = new SelectList(db.Danhmucs.ToList(), "IdDanhMuc", "TenDanhMuc", baiHat.IdDanhMuc);
            ViewBag.NgheSi = new SelectList(db.Nghesis.ToList(), "IdNgheSi", "TenNgheSi", baiHat.IdNgheSi);
            return View(baiHat);
        }

        // Xóa bài hát - GET
        [Route("XoaBaiHat/{idBaiHat}")]
        [HttpGet]
        public IActionResult XoaBaiHat(int idBaiHat)
        {
            var baiHat = db.Baihats.FirstOrDefault(b => b.IdBaiHat == idBaiHat);
            if (baiHat == null)
            {
                return NotFound();
            }

            return View(baiHat);
        }

        // Xóa bài hát - POST
        [Route("XoaBaiHat/{idBaiHat}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaBaiHat(int idBaiHat, IFormCollection form)
        {
            var baiHat = db.Baihats.FirstOrDefault(b => b.IdBaiHat == idBaiHat);
            if (baiHat == null)
            {
                return NotFound();
            }

            try
            {
                db.Baihats.Remove(baiHat);
                db.SaveChanges();
                return RedirectToAction("BaiHat");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Có lỗi khi xóa bài hát: " + ex.Message);
            }

            return View(baiHat);
        }
    }
}
    

