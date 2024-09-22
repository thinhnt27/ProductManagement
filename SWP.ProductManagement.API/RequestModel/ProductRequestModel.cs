namespace SWP.ProductManagement.API.RequestModel
{
    public class ProductRequestModel
    {
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
