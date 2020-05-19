using System;
using System.IO;
using System.Text;
using System.Windows;

namespace MD5
{
    class Program
    {
        #region xarax
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        public static string Decrypt(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        #endregion
        static void Main(string[] args)
        {
            string getpath = Console.ReadLine();
            string topath = Console.ReadLine();
            try
            {
                StreamReader ds = new StreamReader(getpath);
                string pass = RandomPassword();
                StreamWriter wri = new StreamWriter(topath);
                wri.Write(Decrypt(ds.ReadToEnd()));



                Console.WriteLine("Successfully cracked to " + topath);
                Console.ReadKey();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                Environment.Exit(0);
            }

        }

    }
}
