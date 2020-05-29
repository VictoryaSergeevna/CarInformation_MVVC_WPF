using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Helpers;

namespace WpfApp6.Models
{
    public class Car : ObservableObject
    {
        private string manufacturer;

        public string Manufacturer
        {
            get { return manufacturer; }

            set
            {
                if (manufacturer != value)
                {

                    manufacturer = value;
                    OnPropertyChanged(nameof(Manufacturer));
                }
            }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged(nameof(Model));
                }

            }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set
            {
                if (year != value)
                {
                    year = value;
                    OnPropertyChanged(nameof(Year));
                }
            }
        }

        public Car Clone()
        {
            Car newCar = new Car();
            newCar.Manufacturer = this.Manufacturer;
            newCar.Model = this.Model;
            newCar.Year = this.Year;
            return newCar;
        }


    }
}
