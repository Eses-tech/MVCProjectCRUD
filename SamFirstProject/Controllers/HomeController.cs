using SamFirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamFirstProject.Controllers
{
    public class HomeController : Controller
    {
        
        

        public ActionResult Index()
        {
            DatabaseContext _context = new DatabaseContext();
            List<Customer> _customers = _context.Customers.ToList();
            return View(_customers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(string FirstName,string LastName,string PhoneNumber,string Address,string FaultReason,string UsedMaterial,string Explanation)
        {

            Customer _customer = new Customer();
            _customer.Address = Address;
            _customer.Explanation = Explanation;
            _customer.FaultReason = FaultReason;
            _customer.FirstName = FirstName;
            _customer.LastName = LastName;
            _customer.PhoneNumber = PhoneNumber;
            _customer.UsedMaterial = UsedMaterial;
            DatabaseContext _context = new DatabaseContext();
            _context.Customers.Add(_customer);
            _context.SaveChanges();
            return   RedirectToAction("AddedCustomer", "Home"); ;
        }

        public ActionResult AddedCustomer()
        {
            return View();
        }
        
        public ActionResult CustomerUpdateDetail(int id)
        {
            DatabaseContext _context = new DatabaseContext();
            Customer _customer = _context.Customers.Find(id);


            return View(_customer);
        }

        [HttpPost]
        public ActionResult CustomerUpdate(int id,string FirstName, string LastName, string PhoneNumber, string Address, string FaultReason, string UsedMaterial, string Explanation)
        {
            DatabaseContext _context = new DatabaseContext();
            Customer _customer = _context.Customers.Find(id);
            _customer.Explanation = Explanation;
            _customer.FaultReason = FaultReason;
            _customer.FirstName = FirstName;
            _customer.LastName = LastName;
            _customer.PhoneNumber = PhoneNumber;
            _customer.UsedMaterial = UsedMaterial;
            _customer.Address = Address;
            _context.Customers.Update(_customer);

            _context.SaveChanges();


            return View();
        }

        public ActionResult CustomerDeleteDetail(int id)
        {
            DatabaseContext _context = new DatabaseContext();
            Customer _customer = _context.Customers.Find(id);
          

            return View(_customer);
        }
        
        public ActionResult CustomerDelete(int id)
        {
            DatabaseContext _context = new DatabaseContext();
            Customer _customer = _context.Customers.Find(id);
            if (_customer != null)
            {
                _context.Customers.Remove(_customer);
            }
            _context.SaveChanges();

            ViewBag.Message = "Müşteri Başarı ile Silindi";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        
    }
}