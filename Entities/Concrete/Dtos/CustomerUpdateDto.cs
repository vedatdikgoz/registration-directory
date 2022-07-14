
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete.Dtos
{
    public class CustomerUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? Image { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
