using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace School.Helper
{
    public static class Helpers
    {
        /// <summary>
        /// Convert from string to Currency
        /// </summary>
        /// <param name="String"></param>
        /// <returns></returns>
        public static decimal StringToCurrency(string String)
        {
            if (!String.IsNullOrEmpty(String) || !String.IsNullOrWhiteSpace(String))
                String = string.Format("{0:C}", decimal.Parse(String));
            return (decimal.Parse(String));
        }

        public static float CurrencyToString(string String)
        {
            float sal;
            int n = Int16.Parse(String.Length.ToString());
            if (String.Substring(0, 1) == "$")
                sal = float.Parse(String.Substring(1, n - 1));
            else
            {
                sal = float.Parse(String);
            }
            return sal;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage;
            try
            {
                if (byteArrayIn != null)
                {
                    MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                    ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                    returnImage = Image.FromStream(ms, true); //Exception occurs here
                }
                else
                {
                    returnImage = null;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return returnImage;
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public static byte[] StringToByteArray(string stringValue)
        {
            byte[] photo = null;
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                photo = File.ReadAllBytes(stringValue);
            }
            return (photo);
        }

        public static bool CheckEmpty(ErrorProvider ep,
            params Control[] ctr)
        {
            int n = ctr.GetUpperBound(0);
            bool b = false;
            for (int i = 0; i <= n; i++)
            {
                if (string.IsNullOrWhiteSpace(ctr[i].Text))
                {
                    ep.SetError(ctr[i], "Missing Value");// + ctr[i].Tag //You can enter tag all control
                    // ctr[i].Name.Substring(3, ctr[i].Name.Length - 3));
                    b = true;
                }
            }
            return (b);
        }

        internal static bool CheckEmpty(object errorProvider1, object txtNameInKhmer, object txtNameInEnglish, object txtEmail, object txtPhone, object txtLocation)
        {
            throw new NotImplementedException();
        }
    }
}