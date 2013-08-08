using System.Windows;
using Microsoft.Practices.EnterpriseLibrary.Logging;


namespace AHED
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Logger.Write("We made it to the startup!");
        }
    }
}
