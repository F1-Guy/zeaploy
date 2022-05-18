namespace zeaploy.Services.Interfaces
{
    public interface IFileService
    {
        public Task UploadProfilePictureAsync(IFormFile profilePicture, string email);
        public Task UploadApplicationFileAsync(IFormFile applicationFile, string email, string companyName);
        public Task UploadCompanyLogoAsync(IFormFile companyLogo, string name);
        public void DeleteProfilePicture(string name);
        public void DeleteCompanyLogo(string name);
        public void DeleteApplicationFiles(string name, string companyName);
    }
}
