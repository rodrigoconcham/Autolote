using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;



namespace autolote.Helper
{
    
    public enum Tamanos
    {

        Miniatura,
        Mediana
    }
    
    
    
    
    class GuardarImagen
    {

     public string ResizeAndSave(string FileName , Stream imageBuffer, Tamanos tamano, bool makeItSquare)
      {

          int newWidth;
          int newHeight;
          Image image = Image.FromStream(imageBuffer);
          int oldWidth = image.Width;
          int oldHeight = image.Height;
          Bitmap newImage;
          string savePath;
          int maxSideSize;
          string urlImagen = string.Empty;

          string serverPath = HttpContext.Current.Server.MapPath("~");
          string imagesPath =serverPath + "Content\\Imagenes\\";

          if (tamano == Tamanos.Miniatura)
          {
              urlImagen += "~/content/imagenes/Miniatura/" + FileName + ".jpg";
              maxSideSize = 80;
              savePath = imagesPath + "Miniatura\\" + FileName + ".jpg";
           
          }

          else
          {

              urlImagen += "~/content/imagenes/Mediana/" + FileName + ".jpg";
              maxSideSize = 80;
              savePath = imagesPath + "Mediana\\" + FileName + ".jpg";

          }


          if (makeItSquare)
          {
              int smallerSide = oldWidth >= oldHeight ? oldHeight : oldWidth;
              double coeficient = maxSideSize / (double)smallerSide;
              newWidth = Convert.ToInt32(coeficient * oldWidth);
              newHeight = Convert.ToInt32(coeficient * oldHeight);
              Bitmap tempImage = new Bitmap(image, newWidth, newHeight);
              int cropx = (newWidth - maxSideSize) / 2;
              int cropy = (newHeight - maxSideSize) / 2;
              newImage = new Bitmap(maxSideSize, maxSideSize);
              Graphics tempGraphics = Graphics.FromImage(newImage);
              tempGraphics.SmoothingMode = SmoothingMode.AntiAlias;
              tempGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
              tempGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
              tempGraphics.DrawImage(tempImage, new Rectangle(0, 0, maxSideSize, maxSideSize));
          }

          else
          {
              int maxside = oldWidth >= oldHeight ? oldWidth : oldHeight;

              if (maxside > maxSideSize)
              {
                  double coeficient = maxSideSize / (double)maxside;
                  newWidth = Convert.ToInt32(coeficient * oldWidth);
                  newHeight = Convert.ToInt32(coeficient * oldHeight);

              }

              else
              {
                  newWidth = oldWidth;
                  newHeight = oldHeight;

              }
              newImage = new Bitmap(image, newWidth, newHeight);
          }

          newImage.Save(savePath, ImageFormat.Jpeg);
          image.Dispose();

          return urlImagen;



      }

    }
}
