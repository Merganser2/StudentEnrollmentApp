namespace StudentEnrollment.API.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileUpload(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        string IFileUpload.UploadStudentFile(byte[] file, string imageName)
        {
            if (file == null)
            {
                return string.Empty; 
            }

            var folderPath = "studentpictures";
            var url = _httpContextAccessor.HttpContext?.Request.Host.Value;
            var ext = Path.GetExtension(imageName);
            var fileName = $"{Guid.NewGuid()}{ext}";

            var path = $"{_webHostEnvironment.WebRootPath}\\{folderPath}\\{fileName}";
            UploadImage(file, path);
            return $"https://{url}/{folderPath}/{fileName}";
        }

        private void UploadImage(byte[] fileBytes, string filePath)
        {
            FileInfo file = new(filePath);
            file?.Directory?.Create(); // does nothing if filePath exists

            var fileStream = file?.Create();
            fileStream?.Write(fileBytes, 0, fileBytes.Length);
            fileStream?.Close();
        }
    }
}
