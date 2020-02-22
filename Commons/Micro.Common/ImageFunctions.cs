using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System;
using System.Drawing.Drawing2D;

namespace Micro.Commons
{
	public class ImageFunctions
	{
		public static Image ByteToImage(byte[] ImgByte)
		{
            MemoryStream ImageStream = new MemoryStream(ImgByte);
            Image Img = Image.FromStream(ImageStream);
            return Img;
		}

		public static byte[] ImageToByte(Image img)
		{
            MemoryStream ImageStream = new MemoryStream();
            img.Save(ImageStream, ImageFormat.Jpeg);
            return ImageStream.ToArray();
		}

		public static Image BrowseImage()
		{
            System.Windows.Forms.OpenFileDialog OpenDialog = new System.Windows.Forms.OpenFileDialog();
            OpenDialog.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|Bitmap Files (*.bmp)|*.bmp";

            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(OpenDialog.FileName);
                Image img = Image.FromFile(OpenDialog.FileName);
                return img;
            }
            else
            {
                return null;
            }
		}

		/// <summary>
		/// This method can be used to resize image with high quality of resizing
		/// </summary>
		/// <param name="fromFileName">The full path of the source file</param>
		/// <param name="toFileName">The full path of the destination file</param>
		/// <param name="toMimeType">supported mime types are image/jpeg, image/png, image/gif, image/tiff, image/bmp</param>
		/// <param name="resizeRatio">The resize ratio. 0.5 means a image reduced by 2</param>
		public static void ResizeImage(string fromFileName, string toFileName, string toMimeType, double resizeRatio)
		{
			// Get the source Bitmap.
			Bitmap fromBitmap = new Bitmap(fromFileName);

			// Calculate with of the destination and make the destination Bitmap.
			int sourceImageWidth = (int)((double)fromBitmap.Width * resizeRatio);
			int sourceImageHeight = (int)((double)fromBitmap.Height * resizeRatio);
			Bitmap toBitmap = new Bitmap(sourceImageWidth, sourceImageHeight);

			// Copy the source image.
			Graphics destinationGraphics = Graphics.FromImage(toBitmap);

			// Ensure a good quality of interpolation
			destinationGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

			destinationGraphics.DrawImage(fromBitmap, 0, 0, sourceImageWidth, sourceImageHeight);
			EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
			encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 75L);
			toBitmap.Save(toFileName, GetEncoderInfo(toMimeType), encoderParams);
		}

		/// <summary>
		/// This method can be used to resize image with high quality of resizing
		/// </summary>
		/// <param name="fromFileName">The full path of the source file</param>
		/// <param name="toFileName">The full path of the destination file</param>
		/// <param name="toMimeType">supported mime types are image/jpeg, image/png, image/gif, image/tiff, image/bmp</param>
		/// <param name="finalWidth">Final required width. Height is calculated to keep original ratio</param>
		public static void ResizeImage(string fromFileName, string toFileName, string toMimeType, int finalWidth)
		{
			// Get the source Bitmap.
			Bitmap fromBitmap = new Bitmap(fromFileName);

			// Calculate with of the destination and make the destination Bitmap.
			double resizeRatio = (double)finalWidth / (double)fromBitmap.Width;
			int sourceImageWidth = (int)((double)fromBitmap.Width * resizeRatio);
			int sourceImageHeight = (int)((double)fromBitmap.Height * resizeRatio);
			Bitmap toBitmap = new Bitmap(sourceImageWidth, sourceImageHeight);

			// Copy the source image.
			Graphics destinationGraphics = Graphics.FromImage(toBitmap);

			// Ensure a good quality of interpolation
			destinationGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

			destinationGraphics.DrawImage(fromBitmap, 0, 0, sourceImageWidth, sourceImageHeight);
			EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
			encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 75L);
			toBitmap.Save(toFileName, GetEncoderInfo(toMimeType), encoderParams);
		}

		/// <summary>
		/// Get an ancoder from the mime type (image/jpeg, image/png,..)
		/// </summary>
		/// <param name="mimeType"></param>
		/// <returns></returns>
		private static ImageCodecInfo GetEncoderInfo(String mimeType)
		{
			int j;
			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for (j = 0; j < encoders.Length; ++j)
			{
				if (encoders[j].MimeType == mimeType)
					return encoders[j];
			}
			return null;
		}
	}
}
