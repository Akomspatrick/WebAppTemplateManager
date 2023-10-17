using System.Drawing.Imaging;

namespace WebApplication1
{
    public class ImageResult
    {
        public string ImageType { get; set; }
        public string Extension { get; set; }
        public ImageFormat TheImageFormat { get; set; }
        public ImageResult(string imagetype)
        {

            ImageType = imagetype;
           
        }

        private ImageResult(ImageFormat theImageFormat, string imagetype, string extension)
        {
            TheImageFormat = theImageFormat;
            ImageType = imagetype;
            Extension = extension;
        }
        public ImageResult Create()

         => ImageType switch
         {
             "jpeg" => new ImageResult(ImageFormat.Jpeg, "image/jpeg", ".jpeg"),
             "png" => new ImageResult(ImageFormat.Png, "image/png", ".png"),
             "gif" => new ImageResult(ImageFormat.Gif, "image/gif", ".gif"),
             "bmp" => new ImageResult(ImageFormat.Bmp, "image/bmp", ".bmp"),
             "tiff" => new ImageResult(ImageFormat.Tiff, "image/tiff", ".tiff"),
             "wmf" => new ImageResult(ImageFormat.Wmf, "image/Wmf", ".wmf"),
             "emf" => new ImageResult(ImageFormat.Emf, "image/emf", ".emf"),
             _ => new ImageResult(ImageFormat.Jpeg, "image/jpeg", ".jpeg"),
         };

    }
}
