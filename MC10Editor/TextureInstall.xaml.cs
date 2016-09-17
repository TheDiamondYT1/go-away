using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MC10Editor
{
    /// <summary>
    /// Interaction logic for TextureInstall.xaml
    /// </summary>
    public partial class TextureInstall : Page
    {
        ProgressDialog p = null;
        string fileName;
        string filePath;

        public TextureInstall()
        {
            InitializeComponent();
            p = new ProgressDialog();
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)); //C:\Users\YourName
            path = Path.Combine(path, "Downloads"); //C:\Users\YourName\Downloads

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Select Texture Pack";
            dialog.DefaultExt = ".zip";
            dialog.Filter = "ZIP files|*.zip|All Files|*.*";
            dialog.InitialDirectory = path;

            if (dialog.ShowDialog() == true)
            {
                fileName = Path.GetFileName(dialog.FileName);
                filePath = Path.GetFullPath(dialog.FileName);
                textBoxPath.Text = dialog.FileName; //TODO: Something i wont mention :P
                buttonInstall.IsEnabled = true;
            }
        }

        private void buttonInstall_Click(object sender, RoutedEventArgs e)
        {
            p.Show();
            string dest = Utils.GetTexturesPath();

            new Thread(() => Utils.CopyFile(filePath, dest, p.progressBar)).Start();
            Utils.CopyFile(filePath, dest, p.progressBar);
        }

        private void CopyFinished()
        {
            p.labelCopying.FontSize = 10;
            p.labelCopying.Content = "Texture " + fileName + " installed.";
            p.Title = "Install Success";
            p.buttonLaunch.Visibility = Visibility.Visible;
        }
    }
}
