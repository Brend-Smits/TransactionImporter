using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.Factory;
using TransactionImporter.WebUI.Models;
using TransactionImpoter.Domain;

namespace TransactionImporter.WebUI.Controllers
{
    public class CountryContinentController : Controller
    {
        private ICountryContinentLogic countryContinentLogic = CountryContinentFactory.CreateLogic();
        // GET: CountryContinent
        public ActionResult Index()
        {
            List<CountryContinent> countryContinents = countryContinentLogic.GetAllCountries();
            List<CountryContinentModels> countryModels = new List<CountryContinentModels>();
            foreach (CountryContinent country in countryContinents)
            {
                countryModels.Add(new CountryContinentModels(country.Country, country.Continent));
            }
            return View(countryModels);
        }

        // GET: CountryContinent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryContinent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryContinent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryContinent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CountryContinent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryContinent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CountryContinent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
