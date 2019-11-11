using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Areas.Admin.Controllers
{
    public class FullContractController : Controller
    {
		// GET: Admin/FullContract
		QUANLYBDSEntities model = new QUANLYBDSEntities();
		public ActionResult Index()

        {
			var fullcontract = model.Full_Contract.OrderByDescending(x => x.ID).ToList();
            return View(fullcontract);
        }
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.property = model.Properties.OrderByDescending(x => x.ID).ToList();
			return View();
		}
		[HttpPost]
		public ActionResult Create(Full_Contract c)
		{
			var contract = new Full_Contract();
			contract.FullContractCode = c.FullContractCode;
			contract.CustomerName = c.CustomerName;
			contract.YearOfBirth = c.YearOfBirth;
			contract.SSN = c.SSN;
			contract.CustomerAddress = c.CustomerAddress;
			contract.Mobile = c.Mobile;
			contract.DateOfContract = c.DateOfContract;
			contract.Price = c.Price;
			contract.Deposit = c.Deposit;
			contract.Remain = c.Remain;
			contract.Status = c.Status;
			contract.PropertyID = c.PropertyID;
			model.Full_Contract.Add(contract);
			model.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var fullcontract = model.Full_Contract.FirstOrDefault(x => x.ID == id);
			ViewBag.property = model.Properties.OrderByDescending(x => x.ID).ToList();
			return View(fullcontract);
		}
		[HttpPost]
		public ActionResult Edit(int id, Full_Contract c)
		{
			var contract = model.Full_Contract.FirstOrDefault(x => x.ID == id);
			contract.FullContractCode = c.FullContractCode;
			contract.CustomerName = c.CustomerName;
			contract.YearOfBirth = c.YearOfBirth;
			contract.SSN = c.SSN;
			contract.CustomerAddress = c.CustomerAddress;
			contract.Mobile = c.Mobile;
			contract.DateOfContract = c.DateOfContract;
			contract.Price = c.Price;
			contract.Deposit = c.Deposit;
			contract.Remain = c.Remain;
			contract.Status = c.Status;
			contract.PropertyID = c.PropertyID;
			model.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}