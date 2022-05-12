namespace zeaploy.Services.Interfaces
{
    public interface IFileService
    {
        public Task UploadProfilePictureAsync(IFormFile profilePicture, string email);
        public Task UploadApplicationFileAsync(IFormFile applicationFile, string email);
        public Task UploadCompanyLogoAsync(IFormFile companyLogo, string name);
    }
}
