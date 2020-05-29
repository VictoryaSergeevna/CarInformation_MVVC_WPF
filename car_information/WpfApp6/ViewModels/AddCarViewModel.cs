using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Models;
using WpfApp6.Helpers;
using System.Windows;
using System.Windows.Input;

namespace WpfApp6.ViewModels
{
    public class AddCarViewModel: ObservableObject
    {
        Window window;
        Car car;
        public AddCarViewModel(Window window, Car car)
        {
            this.window = window;
            this.car = car;
            this.okCommand = new RelayCommand(OkBtnClick);
            this.cancelCommand = new RelayCommand(CancelBtnClick);
        }

        public Car Car
        {
            get { return car; }
            set
            {
                if (car != value)
                {
                    car = value;
                    OnPropertyChanged(nameof(Car));
                }
            }
        }
        //второй способ
        ICommand okCommand;
        ICommand cancelCommand;
        public  ICommand OkCommand
        {
            get => okCommand;
        }
        
        public ICommand CancelCommand
        {
            get => cancelCommand;
        }

        private void OkBtnClick(object sender)
        {
            window.DialogResult = true;
        }

        private void CancelBtnClick(object sender)
        {
            window.DialogResult = false;
        }
    }
}
