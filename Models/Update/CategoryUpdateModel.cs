namespace Api_uppgift_1.Models.Update
{
    public class CategoryUpdateModel
    {
        public CategoryUpdateModel(string categoryName)
        {
            CategoryName = categoryName;
        }

        public string CategoryName { get; set; }
    }
}
