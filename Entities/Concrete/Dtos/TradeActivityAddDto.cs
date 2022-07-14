using Core.Entities;

namespace Entities.Concrete.Dtos
{
    public class TradeActivityAddDto:IDto
    {
        public string Labor { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
    }
}
