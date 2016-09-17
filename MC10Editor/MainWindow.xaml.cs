using System.Windows;

namespace MC10Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonTextures_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new TextureInstall();
        }

        private void buttonMaps_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
