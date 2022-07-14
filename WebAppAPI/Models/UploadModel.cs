namespace WebAppAPI.Models
{
    public class UploadModel
    {
        public string? NewName { get; set; }
        public string ErrorMessage { get; set; }
        public bool UploadState { get; set; }
    }
}
