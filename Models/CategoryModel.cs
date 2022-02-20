namespace Api_uppgift_1.Models
{
    public class CategoryModel
    {
        public CategoryModel(string categoryName)
        {
            CategoryName = categoryName;
        }

        public string CategoryName { get; set; }
    }
}
