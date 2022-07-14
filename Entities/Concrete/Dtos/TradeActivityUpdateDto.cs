using Core.Entities;

namespace Entities.Concrete.Dtos
{
    public class TradeActivityUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Labor { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
    }
}
