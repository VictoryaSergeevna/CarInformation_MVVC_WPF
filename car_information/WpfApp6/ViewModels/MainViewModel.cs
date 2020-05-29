using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Models;
using System.Collections.ObjectModel;
using WpfApp6.Helpers;
using System.Windows.Input;

namespace WpfApp6.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<Car> Cars { get; set; }
        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (selectedCar != value)
                {
                    selectedCar = value;
                    OnPropertyChanged(nameof(SelectedCar));
                }


            }
        }
        public MainViewModel()
        {
            Cars = new ObservableCollection<Car>();
            Cars.Add(new Car { Manufacturer = "BMV", Model = "X7", Year = 2017 });
            Cars.Add(new Car { Manufacturer = "Mercedes", Model = "X7", Year = 2015 });
            editCommand = new RelayCommand(editCar);
        }

        RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                //если null возвращается первая часть, если нет вторая
                return addCommand ?? (addCommand = new RelayCommand(
                    (obj) =>
                    {
                        Car car = new Car();
                        Cars.Add(car);
                        SelectedCar = car;
                    }
                    ));
            }
        }
        RelayCommand deleteCommand;

        //первый способ
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(
                  (obj) =>
                  {
                      Car car = obj as Car;
                      if (car != null)
                      {
                          Cars.Remove(car);
                      }
                  },
                  //(obj)=>{return Cars.Count>0;}
                  obj=>(Cars.Count >0)
                    ));
            }
        }

        ICommand editCommand;
        public ICommand EditCommand { get => editCommand; }
        private void editCar(object param)
        {
            Car car = param as Car;
            if (car != null)
            {
                Car newCar = car.Clone();
                AddCarWindow window = new AddCarWindow(newCar);
                
                if (window.ShowDialog() == true)
                {
                 
                        int n = Cars.IndexOf(car);
                        Cars[n] = newCar;
                    
                }
            }
        }
    }
}
