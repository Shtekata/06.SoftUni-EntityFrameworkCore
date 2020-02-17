namespace PetStore.Services.implementation
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Services.Models.Category;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly PetStoreDbContext data;
        public CategoryService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<AllCategoriesServiceModel> All()
        {
            return data.Categories
                .Select(x => new AllCategoriesServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .ToArray();
        }

        public void Create(CreateCategoryServiceModel model)
        {
            var category = new Category()
            {
                Name = model.Name,
                Description = model.Description
            };

            data.Categories.Add(category);
            data.SaveChanges();
        }

        public void Edit(EditCategoryServiceModel model)
        {
            var category = data.Categories
                .Find(model.Id);

            category.Name = model.Name;
            category.Description = model.Description;
            data.SaveChanges();
        }

        public bool Exists(int categoryId)
        {
            return data.Categories.Any(x => x.Id == categoryId);
        }

        public DetailsCategoryServiceModel GetById(int id)
        {
            var category = data.Categories
                .Find(id);

            var dcsm = new DetailsCategoryServiceModel() { Id = category?.Id, Name = category?.Name, Description = category?.Description };

            return dcsm;
        }

        public bool Delete(int id)
        {
            var category = data.Categories
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (category == null) { return false; }

            data.Categories.Remove(category);
            var deletedEntitiesCount = data.SaveChanges();

            if (deletedEntitiesCount == 0) { return false; }

            return true;
        }
    }
}
