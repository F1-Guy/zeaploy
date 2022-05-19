namespace zeaploy.Services.Services
{
    public class FileService : IFileService
    {
        public void DeleteProfilePicture(string name)
        {
            string relativePath = $@"wwwroot\user-data\profile-pictures\{name}\";
            Directory.Delete(relativePath, true);
        }

        public void DeleteCompanyLogo(string name)
        {
            string relativePath = $@"wwwroot\company-logos\{name}\";
            Directory.Delete(relativePath, true);
        }

        public void DeleteApplicationFiles(string name, string companyName)
        {
            string relativePath = $@"wwwroot\user-data\cv-letters\{name}\{companyName}";
            Directory.Delete(relativePath, true);
        }

        public async Task UploadApplicationFileAsync(IFormFile applicationFile, string name, string companyName)
        {
            string[] allowedExtensions = new[] { ".pdf", ".doc", ".txt", ".docx" };
            string relativePath = $@"wwwroot\user-data\cv-letters\{name}\{companyName}";
            Directory.CreateDirectory(relativePath);
            var file = Path.Combine(relativePath, applicationFile.FileName);
            if (!allowedExtensions.Contains(Path.GetExtension(file)))
            {
                throw new InvalidDataException("You tried to upload an invalid file type");
            }
            else
            {
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await applicationFile.CopyToAsync(fileStream);
                }
            }
        }

        public async Task UploadCompanyLogoAsync(IFormFile companyLogo, string name)
        {
            string[] allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string relativePath = $@"wwwroot\company-logos\{name}\";
            var file = Path.Combine(relativePath, companyLogo.FileName);
            if (!allowedExtensions.Contains(Path.GetExtension(file)))
            {
                throw new InvalidDataException("You tried to upload an invalid file type");
            }
            else
            {
                Directory.CreateDirectory(relativePath);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await companyLogo.CopyToAsync(fileStream);
                }
            }
        }

        public async Task UploadProfilePictureAsync(IFormFile ProfilePicture, string name)
        {
            string[] allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string relativePath = $@"wwwroot\user-data\profile-pictures\{name}\";
            var file = Path.Combine(relativePath, ProfilePicture.FileName);
            if (!allowedExtensions.Contains(Path.GetExtension(file)))
            {
                throw new InvalidDataException("You tried to upload an invalid file type");
            }
            else
            {
                Directory.CreateDirectory(relativePath);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await ProfilePicture.CopyToAsync(fileStream);
                }
            }
        }
    }
}
