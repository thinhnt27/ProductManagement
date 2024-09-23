namespace SWP.ProductManagement.API.ResponseModel
{
    public class CategoryResponseModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductResponseModel> Products { get; set; } = new List<ProductResponseModel>();
    }
}
