namespace zeaploy.Services.Interfaces
{
    public interface IFileService
    {
        public Task UploadProfilePictureAsync(IFormFile profilePicture, string id);
        public Task UploadApplicationFileAsync(IFormFile applicationFile, string email, string companyName);
        public Task UploadCompanyLogoAsync(IFormFile companyLogo, int advertisementId);
        public void DeleteProfilePicture(string id);
        public void DeleteCompanyLogo(int advertisementId);
        public void DeleteApplicationFiles(string name, string companyName);
    }
}
