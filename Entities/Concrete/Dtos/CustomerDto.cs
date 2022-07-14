

namespace Entities.Concrete.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public List<TradeActivity> TradeActivities { get; set; }

    }
}
