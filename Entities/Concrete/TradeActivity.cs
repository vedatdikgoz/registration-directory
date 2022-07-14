using Core.Entities;

namespace Entities.Concrete
{
    public class TradeActivity:IEntity
    {
        public int Id { get; set; }
        public string Labor { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
