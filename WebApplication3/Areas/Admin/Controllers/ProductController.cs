using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
		// GET: Admin/Product
		QUANLYBDSEntities model = new QUANLYBDSEntities();
        public ActionResult Index()
        {
			var property = model.Properties.OrderByDescending(x => x.ID).ToList();
            return View(property);
        }
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var property = model.Properties.FirstOrDefault(x => x.ID == id);
			ViewBag.property_type = model.Property_Type.OrderByDescending(x => x.ID).ToList();
			ViewBag.district = model.Districts.OrderByDescending(x => x.ID).ToList();
			ViewBag.status = model.Property_Status.OrderByDescending(x => x.ID).ToList();
			return View(property);
		}
		[HttpPost]
		public ActionResult Edit(int id, Property p)
		{
			var property = model.Properties.FirstOrDefault(x => x.ID == id);
			property.PropertyName = p.PropertyName;
			property.Price = p.Price;
			property.Description = p.Description;
			property.Avatar = p.Avatar;
			property.Address = p.Address;
			property.Area = p.Area;
			property.BedRoom = p.BedRoom;
			property.BathRoom = p.BathRoom;
			property.DistrictID = p.DistrictID;
			property.PropertyStatusID = p.PropertyStatusID;
			property.PropertyTypeID = p.PropertyTypeID;
			property.InstallmentRate = p.InstallmentRate;
			model.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.property_type = model.Property_Type.OrderByDescending(x => x.ID).ToList();
			ViewBag.district = model.Districts.OrderByDescending(x => x.ID).ToList();
			ViewBag.status = model.Property_Status.OrderByDescending(x => x.ID).ToList();
			return View();
			
		}
		[HttpPost]
		public ActionResult Create(Property p)
		{
			var property = new Property();
			property.PropertyName = p.PropertyName;
			property.Price = p.Price;
			property.Description = p.Description;
			property.Avatar = p.Avatar;
			property.Address = p.Address;
			property.Area = p.Area;
			property.BedRoom = p.BedRoom;
			property.BathRoom = p.BathRoom;
			property.DistrictID = p.DistrictID;
			property.PropertyStatusID = p.PropertyStatusID;
			property.PropertyTypeID = p.PropertyTypeID;
			property.InstallmentRate = p.InstallmentRate;
			model.Properties.Add(property);
			model.SaveChanges();
			return RedirectToAction("Index");
		} 
		[HttpGet]
		public ActionResult Delete(int id)
		{
			var property = model.Properties.FirstOrDefault(x => x.ID == id);
			return View(property);
		}
		[HttpPost]
		[ActionName ("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			var property = model.Properties.FirstOrDefault(x => x.ID == id);
			model.Properties.Remove(property);
			model.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Details(int id)
		{
			var property = model.Properties.FirstOrDefault(x => x.ID == id);
			return View(property);
		}
	}
}