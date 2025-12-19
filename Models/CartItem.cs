namespace BlazorUI.Models{

    public class CartItem
    {
        public string CoffeeName{get; set;}
        public string Size{get;set;}
        public int SmallPrice { get; set; }
        public int MediumPrice { get; set; }
        public int LargePrice { get; set; }
        public int TotalPrice{get;set;}
        public int Quantity{get;set;}
        public string ImageCart { get; set; }
        public int UnitPrice { get; set; }

    }
}