using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace MC10Editor
{
    /// <summary>
    /// Interaction logic for ProgressDialog.xaml
    /// </summary>
    public partial class ProgressDialog : Window
    {
        public static ProgressBar progress;

        public ProgressDialog()
        {
            InitializeComponent();
            progress = progressBar;
        }

        private void buttonLaunch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("minecraft://");
            } catch(Win32Exception ex)
            {
                MessageBox.Show("There was an error while launching Minecraft " + ex.Message, "Canno't launch Minecraft", MessageBoxButton.OK);
                return;
            }
        }

        // Prevent ObjectDisposedEvent
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            e.Cancel = true;
            this.Hide();
        }
    }
}
