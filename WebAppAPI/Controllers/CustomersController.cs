using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebAppAPI.Models;
using WebAppAPI.Services;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        private readonly RabbitMQPublisher _rabbitMQPublisher;
      
        public CustomersController(ICustomerService customerService, RabbitMQPublisher rabbitMQPublisher)
        {
            _customerService = customerService;
            _rabbitMQPublisher= rabbitMQPublisher;
        }



        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("whohavesamephone")]
        public async Task<IActionResult> GetAllWhoHaveSamePhone()
        {
            var result = await _customerService.GetAllWhoHaveSamePhoneAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getallwithtradeactivity")]
        public async Task<IActionResult> GetAllWithTradeActivity()
        {
            var result = await _customerService.GetAllCustomersWithTradeActivityAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("get")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }




        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CustomerAddDto customerAddDto)
        {

            var uploadModel = await UploadFileAsync(customerAddDto.Image, "image/jpeg");

            if (uploadModel.UploadState==false)
            {
                return BadRequest(uploadModel.ErrorMessage);
            }

            _rabbitMQPublisher.Publish(new CustomerImageCreatedEvent() { ImageName = uploadModel.NewName });
            customerAddDto.ImagePath = uploadModel.NewName;
            var result = await _customerService.AddAsync(customerAddDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }



        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CustomerUpdateDto customerUpdateDto)
        {
            var uploadModel = await UploadFileAsync(customerUpdateDto.Image, "image/jpeg");

            if (uploadModel.UploadState == false)
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        
            customerUpdateDto.ImagePath = uploadModel.NewName;
          
            var result = await _customerService.UpdateAsync(customerUpdateDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int customerId)
        {
            var result = await _customerService.DeleteAsync(customerId);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }


        [HttpDelete("bulkdelete")]
        public async Task<IActionResult> BulkDelete(List<int> customerId)
        {
            var result = await _customerService.BulkDeleteAsync(customerId);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }


        private async Task<UploadModel> UploadFileAsync(IFormFile file, string contentType)
        {
            UploadModel uploadModel = new UploadModel();
            if (file != null)
            {
                if (file.ContentType != contentType)
                {
                    uploadModel.ErrorMessage = "Uygunsuz dosya türü";
                    uploadModel.UploadState = false;
                    return uploadModel;
                }

                var randomImageName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + randomImageName);
                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);

                uploadModel.NewName = randomImageName;
                uploadModel.UploadState = true;
                return uploadModel;

            }
            uploadModel.NewName = null;
            uploadModel.UploadState = true;
            return uploadModel;
        }
    }
}