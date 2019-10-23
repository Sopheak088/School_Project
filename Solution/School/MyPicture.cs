using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using School.Helper;

namespace School
{
    public partial class MyPicture : UserControl
    {
        public MyPicture()
        {
            InitializeComponent();
        }

        public static string FullPath = String.Empty;
        public static byte[] PhotoByte = null;
        public static string OnlyFileName = string.Empty;

        public static string GetStringFullPath()
        {
            return FullPath;
        }

        public byte[] GetByteArrayFromBrowse()
        {
            byte[] returnByte = null;
            if (PhotoByte != null)
            {
                returnByte = PhotoByte;
            }
            else
            {
                //var filePath = System.Reflection.Assembly.GetExecutingAssembly().Location + @"\..\..\Resources\photos.png";
                //string path = Path.GetDirectoryName(Application.ExecutablePath);
                //path = path + "/photos.png";
                returnByte = Helpers.ImageToByteArray(School.Properties.Resources.photos);// Helpers.StringToByteArray(path);
            }
            return returnByte;
        }

        public static string GetOnlyFileName()
        {
            return OnlyFileName;
        }

        public void SetImage(Image image = null)
        {
            picture.Image = image;
            if (image != null)
            {
                PhotoByte = Helpers.ImageToByteArray(image);
            }
        }

        public void ClearImage()
        {
            picture.Image = null;
        }

        private void Picture_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = @"JPEG FILE| *.jpg; *.jpeg|PNG FILE|*.png|BMP FILE|*.bmp";
                fd.Title = @"Select an image";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    FullPath = fd.FileName;
                    PhotoByte = Helpers.StringToByteArray(FullPath);
                    OnlyFileName = Path.GetFileName(fd.FileName);
                    picture.Image = Image.FromFile(FullPath);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            FullPath = String.Empty;
            PhotoByte = null;
            OnlyFileName = string.Empty;
            ClearImage();
        }
    }
}