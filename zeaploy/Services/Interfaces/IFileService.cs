namespace zeaploy.Services.Interfaces
{
    public interface IFileService
    {
        public Task UploadProfilePictureAsync(IFormFile profilePicture, string email);
        public Task UploadApplicationFileAsync(IFormFile applicationFile, string email);
    }
}
