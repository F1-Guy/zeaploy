namespace zeaploy.Services.Interfaces
{
    public interface IFileService
    {
        public Task UploadProfilePictureAsync(IFormFile profilePicture, string email);
        public Task UploadApplicationFileAsync(IFormFile applicationFile, string email);
        public Task UploadCompanyLogoAsync(IFormFile companyLogo, string name);
        public void DeleteProfilePicture(string name, string imageName);
        public void DeleteCompanyLogo(string name, string imageName);
        public void DeleteApplicationFile(string name, string imageName);
    }
}
