using Microsoft.AspNetCore.Http;

namespace Web_MVC.Abstract
{
    public interface IFileHelper
    {
        void DeleteFile(string imageUrl);
        string UploadFile(IFormFile file);

    }
}
