using Core.Entities;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImagePath { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public List<TradeActivity> TradeActivities { get; set; }

    }
}
