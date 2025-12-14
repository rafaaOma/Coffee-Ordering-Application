namespace BlazorUI.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
         //coffe price for small size
        public int SmallPrice { get; set; }

        //coffe price for medium size
        public int MediumPrice { get; set; }

        //coffe price for large size
        public int LargePrice { get; set; }
    }
}