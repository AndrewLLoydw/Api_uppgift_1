namespace Api_uppgift_1.Models.Create
{
    public class CreateCategoryModel
    {
        public CreateCategoryModel(string categoryName)
        {
            CategoryName = categoryName;
        }

        public string CategoryName { get; set; }
    }
}
