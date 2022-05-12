namespace zeaploy.Services.Services
{
    public class FileService : IFileService
    {
        public async Task UploadApplicationFileAsync(IFormFile applicationFile, string name)
        {
            string relativePath = $@"wwwroot\user-data\cv-letters\{name}\";
            Directory.CreateDirectory(relativePath);
            var file = Path.Combine(relativePath, applicationFile.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await applicationFile.CopyToAsync(fileStream);
            }
        }

        public async Task UploadProfilePictureAsync(IFormFile ProfilePicture, string name)
        {
            string relativePath = $@"wwwroot\user-data\profile-pictures\{name}\";
            Directory.CreateDirectory(relativePath);
            var file = Path.Combine(relativePath, ProfilePicture.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await ProfilePicture.CopyToAsync(fileStream);
            }
        }
    }
}
