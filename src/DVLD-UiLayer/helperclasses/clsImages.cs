using System;
using DVLD_UiLayer.Logging;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_UiLayer
{
    internal static class clsImages
    {
        public static string SaveImage(string originalPath)
        {
            if (!File.Exists(originalPath))
                throw new FileNotFoundException("Source image not found.", originalPath);

            string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(originalPath)}";
            string newPath = Path.Combine(@"D:\DVLD-People-Images", newFileName);

            File.Copy(originalPath, newPath);
            return newPath;
        }
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }

        public static void RemoveImage(string imagePath, PictureBox pictureBox = null)
        {
            UnloadImageFromPictureBox(pictureBox);

            if (File.Exists(imagePath))
            {
                File.SetAttributes(imagePath, FileAttributes.Normal);
                File.Delete(imagePath);
            }
        }

        public static void UnloadImageFromPictureBox(PictureBox pictureBox)
        {
            if (pictureBox == null) return;

            //if (pictureBox.Image != null)
            //{
            //    pictureBox.Image.Dispose();
            //    pictureBox.Image = null;
            //}
            if (pictureBox.ImageLocation != null) pictureBox.ImageLocation = null;

            //GC.Collect();
            //GC.WaitForPendingFinalizers();
        }

        public static Image LoadImageWithoutLock(string path)
        {
            if (File.Exists(path))
            {
                byte[] imageData = File.ReadAllBytes(path);
                MemoryStream ms = new MemoryStream(imageData); // do NOT dispose this stream
                return Image.FromStream(ms);
            }
            else
                return null;
        }

        public static void LoadImageIntoPictureBox(string path, PictureBox pictureBox)
        {
            if (pictureBox == null)
                throw new ArgumentNullException(nameof(pictureBox));

            UnloadImageFromPictureBox(pictureBox);
            pictureBox.Image = LoadImageWithoutLock(path);
        }
    }
}
