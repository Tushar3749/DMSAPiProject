using Microsoft.AspNetCore.Http;


namespace DMS.Core.Dto
{
    public class FIleUploadDto
    {
        public IFormFile ImageFile { get; set; }
        public string EmployeeID { get; set; }
    }
}
