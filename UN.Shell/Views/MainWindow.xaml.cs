using CommonServiceLocator;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prism.Ioc;
namespace UN.Shell.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IContainerExtension containerProvider)
        {
           InitializeComponent();
           // var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
        }
        public MainWindow(  string id)
        {
         
            InitializeComponent();
            MessageBox.Show(id);
            // var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
        }
    }
}
