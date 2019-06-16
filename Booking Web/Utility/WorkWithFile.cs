using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.Utility
{
    public class WorkWithFile
    {
        private IHostingEnvironment _hostingEnvironment;
        public WorkWithFile(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public string CheckImage(IFormFile ImageUpload)
        {
            if (ImageUpload != null && !string.IsNullOrEmpty(ImageUpload.FileName) && ImageUpload.Length > 0)
            {
                if (ImageUpload.ContentType.ToLower() != "image/jpg" && ImageUpload.ContentType.ToLower() != "image/jpeg" && ImageUpload.ContentType.ToLower() != "image/jpeg" && ImageUpload.ContentType.ToLower() != "image/png")
                {
                    return "file isnt appropriate";
                }
                else
                    return null;
            }
            else
            {
                return "please select one image for your field";
            }
        }
        public string ImageUpoad(IFormFile ImageUpload, string SavePath, int width, int height)
        {
            try
            {
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath,SavePath);
                string Filename = Guid.NewGuid().ToString().Replace("-", "") + ImageUpload.FileName.ToLower();
                string Savepath = Path.Combine(uploads, Filename);
                ImageUpload.OpenReadStream().ResizeImage(width, height, Savepath, Utilty.ImageComperssion.Normal);
                return Filename;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void DeleteImage(string file)
        {
            try
            {
                string root = _hostingEnvironment.WebRootPath;
                file = file.Remove(0, 1);
                string preparefileTodelete = file.Replace('/', '\\');
                string DeleteImage = Path.Combine(root, preparefileTodelete);
                if (System.IO.File.Exists(DeleteImage))
                {
                    System.IO.File.Delete(DeleteImage);
                }
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
        public bool CheckImageIsnull(IFormFile ImageUpload)
        {
            if (ImageUpload != null && !string.IsNullOrEmpty(ImageUpload.FileName) && ImageUpload.Length > 0)
            {
                return false;
            }
            return true;
        }
    }
}
