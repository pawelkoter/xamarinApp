using Xamarin.Forms;

namespace PamoApp.Models
{
    public class ColorModel
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }
        public string Name { get; set; }

        public ColorModel()
        {
            Name = string.Empty;
        }

        public ColorModel(string name, Color sourceColor)
        {
            Name = name;
            Red = sourceColor.R;
            Green = sourceColor.G;
            Blue = sourceColor.B;
        }
    }
}