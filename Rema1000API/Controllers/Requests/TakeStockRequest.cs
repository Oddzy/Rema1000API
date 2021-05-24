using DataAccess.Models;

namespace Rema1000API.Controllers.Requests
{
    public class TakeStockRequest
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

    }
}