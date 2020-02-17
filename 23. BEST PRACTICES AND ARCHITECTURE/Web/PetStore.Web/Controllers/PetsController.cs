namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services.Models.Pet;
    using PetStore.Web.Models.Pet;
    using Services;
    using System.Collections.Generic;

    public class PetsController : Controller
    {
        private readonly IPetService pets;
        public PetsController(IPetService pets) => this.pets = pets;
        public IActionResult All(int page = 1)
        {
            var allPets = pets.All(page);
            var totallPets = pets.Total();

            var model = new AllPetsViewModel
            {
                Pets = allPets,
                CurrentPage = page,
                Total = totallPets
            };

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var pet = pets.Details(id);

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var delete = pets.Delete(id);

            if (!delete)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        //public IEnumerable<PetListingServiceModel> All() => pets.All();

        //public IEnumerable<PetListingResponseModel> All()
        //{
        //    return new List<PetListingResponseModel>
        //    {
        //        new PetListingResponseModel
        //        {
        //            Id=5,
        //            Name="Ivan",
        //            Breed="Kokoshka",
        //            Price=10
        //        },
        //        new PetListingResponseModel
        //        {
        //            Id=5,
        //            Name="Pesho",
        //            Breed="Kokoshka",
        //            Price=15
        //        }
        //    };
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}