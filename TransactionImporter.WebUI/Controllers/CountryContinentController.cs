using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                countryModels.Add(new CountryContinentModels(country.Id, country.Country, country.Continent));
            }

            return View(countryModels);
        }

        // GET: CountryContinent/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: CountryContinent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryContinentModels models)
        {
            if (ModelState.IsValid)
            {
                CountryContinent countryContinent = new CountryContinent(models.Country, models.Continent);
                countryContinentLogic.AddCountry(countryContinent);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: CountryContinent/Edit/5
        public ActionResult Edit(int id)
        {
            CountryContinent countryContinent = countryContinentLogic.GetCountryById(id);
            
            CountryContinentModels model = new CountryContinentModels(countryContinent.Country, countryContinent.Continent);
            return View(model);
        }

        // POST: CountryContinent/Edit/5
        [HttpPost]
        public ActionResult Edit(CountryContinentModels model, FormCollection collection)
        {
            try
            {
                CountryContinent continent = new CountryContinent(model.Country, model.Continent);
                countryContinentLogic.UpdateCountryById(model.Id, continent);

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
            CountryContinent country = countryContinentLogic.GetCountryById(id);
            CountryContinentModels model = new CountryContinentModels(country.Id, country.Country, country.Continent);
            return View(model);
        }

        // POST: CountryContinent/Delete/5
        [HttpPost]
        public ActionResult Delete(CountryContinentModels model)
        {
            try
            {
                countryContinentLogic.RemoveCountryContinentById(model.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}