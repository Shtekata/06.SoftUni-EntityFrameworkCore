namespace PetStore.Web.Models.Pet
{
    using PetStore.Services.Models.Pet;
    using System;
    using System.Collections.Generic;

    public class AllPetsViewModel
    {
        public IEnumerable<PetListingServiceModel> Pets { get; set; }

        public int Total { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => CurrentPage - 1;

        public int NextPage => CurrentPage + 1;

        public bool PreviousDisabled => CurrentPage == 1;

        public bool NextDisabled
        {
            get
            {
                var maxPage = Math.Ceiling((double)Total / 25);

                return maxPage == CurrentPage;
            }
        }
    }
}
