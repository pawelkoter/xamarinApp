namespace PamoApp.DataTransfer
{
    public class WeatherDto
    {
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public string Name { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }
        public string Pressure { get; set; }
    }

    public class Wind
    {
        public string Speed { get; set; }
        public float Deg { get; set; }
    }

    public class Clouds
    {
        public string All { get; set; }
    }
}