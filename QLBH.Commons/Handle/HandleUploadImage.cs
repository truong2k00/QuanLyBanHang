using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Commons.Handle
{
    public class HandleUploadImage
    {
        private static string CloudName = "dnitjp0ng";
        private static string API_Key = "585698477266768";
        private static string API_Secret = "GbL9VfmEBgl_S50c3bwo5h-xnJk";
        public static Account _account = new Account(CloudName, API_Key, API_Secret);
        public static Cloudinary _cloudinary = new Cloudinary(_account);
        public static async Task<string> UploadImage(string user, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentNullException(Common_Constants.CloudUpoad.IsNull_IFormFile);
            }
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = Common_Constants.CloudUpoad.FolderImage.Folder_Product + "/" +
                    user + Common_Constants.CloudUpoad.Sourc_NewImage 
                    + DateTime.Now.Ticks + "image",
                    Transformation = new Transformation().Width(300).Height(400).Crop("fill")
                };
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }
                string imageUrl = uploadResult.SecureUrl.ToString();
                return imageUrl;
            }
        }
    }
}
