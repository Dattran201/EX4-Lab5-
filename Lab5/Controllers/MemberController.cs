using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class MemberController : Controller
    {
        // GET: /Member/CreateOne
        public ActionResult CreateOne()
        {
            return View();
        }

        // POST: /Member/CreateOne
        [HttpPost]
        public ActionResult CreateOne(Member m)
        {
            // chuyển dữ liệu nhận được tới View Details
            return View("Details", m);
        }

        // GET: /Member/CreateTwo
        public ActionResult CreateTwo()
        {
            return View();
        }

        // POST: /Member/CreateTwo
        [HttpPost]
        public ActionResult CreateTwo(Member m)
        {
            // Kiểm tra trống các trường và thông báo lỗi tới VIEW

            if (!m.Id.HasValue || m.Id.Value <= 0) // Kiểm tra nếu Id không có giá trị hoặc không hợp lệ
            {
                ViewBag.Error = "Hãy nhập mã số hợp lệ";
                return View(m); // Trả về m để giữ dữ liệu đã nhập
            }

            if (string.IsNullOrEmpty(m.Username))
            {
                ViewBag.Error = "Hãy nhập tên đăng nhập";
                return View(m);
            }

            if (string.IsNullOrEmpty(m.FullName))
            {
                ViewBag.Error = "Hãy nhập họ và tên";
                return View(m);
            }

            // Kiểm tra tuổi, nếu tuổi là null thì thông báo lỗi
            if (!m.Age.HasValue)
            {
                ViewBag.Error = "Hãy nhập tuổi";
                return View(m);
            }

            if (string.IsNullOrEmpty(m.Email))
            {
                ViewBag.Error = "Hãy nhập Email";
                return View(m);
            }

            // Mẫu kiểm tra Email
            string regexPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(m.Email, regexPattern))
            {
                ViewBag.Error = "Hãy nhập đúng định dạng Email";
                return View(m);
            }

            // Nếu không xảy ra lỗi thì chuyển dữ liệu tới View Details
            return View("Details", m);
        }

        // GET: /Member/CreateThree
        public ActionResult CreateThree()
        {
            return View();
        }

        // POST: /Member/CreateThree
        [HttpPost]
        public ActionResult CreateThree(Member m)
        {
            // Nếu trạng thái dữ liệu của Model hợp lệ thì chuyển dữ liệu tới View Details
            if (ModelState.IsValid)
            {
                return View("Details", m);
            }

            // Quay lại view Three để báo lỗi
            return View(m);
        }

        // GET: /Member/Details
        public ActionResult Details()
        {
            return View();
        }
    }
}
