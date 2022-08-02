namespace PieShopAPI.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => appDbContext.Categories;

        public Category DeleteCategory(int CategoryID)
        {
            var deleteCategory = AllCategories.FirstOrDefault(c => c.CategoryId == CategoryID);
            var delete = this.appDbContext.Categories.Remove(deleteCategory);
            this.appDbContext.SaveChanges();
            return delete.Entity;
        }

        public Category InsertCategory(Category category)
        {
            var insert = this.appDbContext.Categories.Add(category);
            this.appDbContext.SaveChanges();
            return insert.Entity;
        }

        public Category UpdateCategory(Category category)
        {
            var updateCategory = this.appDbContext.Categories.Update(category);
            this.appDbContext.SaveChanges();
            return updateCategory.Entity;
        }
    }
}
