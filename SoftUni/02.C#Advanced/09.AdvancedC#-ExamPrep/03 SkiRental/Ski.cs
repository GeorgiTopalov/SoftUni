
namespace SkiRental
{
    internal class Ski
    {
        string manufacturer;
        string model;
        int year;

        public Ski(string manufacturer, string model, int year)
        {
            this.manufacturer = manufacturer;
            this.model = model;
            this.year = year;
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public override string ToString()
        {
            return $"{this.Manufacturer} - {this.Model} - {this.Year}";
        }
    }
}
