using PersonalDictionary.Core;
using PersonalDictionary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PersonalDictionary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Make use of DI (StructureMap) to initialize a unit of work and call the person service to get
        /// data from Web Service.
        /// </summary>
        /// <param name="unitOfWork"></param>
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Action method to fetch the persons with pets and display in View.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            List<PersonViewModel> PetsByOwnersGender = await _unitOfWork.Persons.GetAllPetsGroupedByOwnersGender();
            //PetsByOwnersGender.ForEach(p => _unitOfWork.Pets.SortPets(p.Pets, Core.Domain.CompareOptions.ByPetName, Core.Domain.SortOrder.Ascending));
            return View(PetsByOwnersGender);
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}