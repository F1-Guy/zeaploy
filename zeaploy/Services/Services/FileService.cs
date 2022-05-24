namespace zeaploy.Services.Services
{
    public class FileService : IFileService
    {
        public void DeleteProfilePicture(string name)
        {
            string relativePath = $@"wwwroot\user-data\profile-pictures\{name}\";
            if (Directory.Exists(relativePath))
            {
                Directory.Delete(relativePath, true);
            }
        }

        public void DeleteCompanyLogo(string name)
        {
            string relativePath = $@"wwwroot\company-logos\{name}\";
            if (Directory.Exists(relativePath))
            {
                Directory.Delete(relativePath, true);
            }
        }

        public void DeleteApplicationFiles(string name, string companyName)
        {
            string relativePath = $@"wwwroot\user-data\cv-letters\{name}\{companyName}";
            if (Directory.Exists(relativePath))
            {
                Directory.Delete(relativePath, true);
            }
        }

        public async Task UploadApplicationFileAsync(IFormFile applicationFile, string name, string companyName)
        {
            string relativePath = $@"wwwroot\user-data\cv-letters\{name}\{companyName}";
            Directory.CreateDirectory(relativePath);
            string file = Path.Combine(relativePath, applicationFile.FileName);
            if (!FileTypes.Documents.Contains(Path.GetExtension(file).ToLower()))
            {
                throw new InvalidDataException("You tried to upload an invalid file type");
            }
            else
            {
                using FileStream fileStream = new(file, FileMode.Create);
                await applicationFile.CopyToAsync(fileStream);
            }
        }

        public async Task UploadCompanyLogoAsync(IFormFile companyLogo, string name)
        {
            string relativePath = $@"wwwroot\company-logos\{name}\";
            string file = Path.Combine(relativePath, companyLogo.FileName);
            if (!FileTypes.Images.Contains(Path.GetExtension(file).ToLower()))
            {
                throw new InvalidDataException("You tried to upload an invalid file type");
            }
            else
            {
                Directory.CreateDirectory(relativePath);
                using FileStream fileStream = new(file, FileMode.Create);
                await companyLogo.CopyToAsync(fileStream);
            }
        }

        public async Task UploadProfilePictureAsync(IFormFile ProfilePicture, string name)
        {
            string relativePath = $@"wwwroot\user-data\profile-pictures\{name}\";
            string file = Path.Combine(relativePath, ProfilePicture.FileName);
            if (!FileTypes.Images.Contains(Path.GetExtension(file).ToLower()))
            {

                throw new InvalidDataException("You tried to upload an invalid file type");
            }
            else
            {
                Directory.CreateDirectory(relativePath);
                using FileStream fileStream = new(file, FileMode.Create);
                await ProfilePicture.CopyToAsync(fileStream);
            }
        }
    }
}
