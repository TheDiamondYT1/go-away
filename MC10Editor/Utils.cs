using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MC10Editor
{
    static class Utils
    {
        private static string baseMCpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
               @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang";

        public static string GetMCPath()
        {
            return baseMCpath;
        }

        public static string GetWorldsPath()
        {
            return GetMCPath() + @"\minecraftWorlds";
        }

        public static string GetTexturesPath()
        {
            return GetMCPath() + @"\resource_packs";
        }

        // Taken from a great StackOverflow answer. Thanks!
        public static void CopyFile(string file, string destination, ProgressBar progressCallback)
        {
            try
            {
                if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);
            } catch (IOException e)
            {
                MessageBox.Show("There was an error while creating the resource packs directory " + e.Message, "Canno't create directory", MessageBoxButton.OK);
                return;
            }


            int halfAMeg = (int)(1024 * 1024 * 0.4);

            FileStream strIn = null;
            FileStream strOut = null;

            try
            {
                strIn = new FileStream(file, FileMode.Open);
                strOut = new FileStream(Path.Combine(destination, file), FileMode.Create);
            }
            catch (IOException e)
            {
                MessageBox.Show("There was an error while copying the file: " + e.Message, "Canno't copy file", MessageBoxButton.OK);
                return;
            }

            byte[] buf = new byte[halfAMeg];
            while (strIn.Position < strIn.Length)
            {
                int len = strIn.Read(buf, 0, buf.Length);
                strOut.Write(buf, 0, len);

                progressCallback.Maximum = Int32.MaxValue;
                progressCallback.Value = (int)(Int32.MaxValue / (strIn.Position / strIn.Length));
            }
        }
    }
}
