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
using System.Windows.Shapes;
using WpfApp6.ViewModels;
using WpfApp6.Models;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public AddCarWindow(Car car)
        {
            InitializeComponent();
            this.DataContext = new AddCarViewModel(this, car);
        }
    }
}
