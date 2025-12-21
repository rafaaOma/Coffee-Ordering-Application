using BlazorUI.Models;
namespace BlazorUI.Services{
public class CartService
{
    public List<CartItem> Items{get;set;} = new();

    public void AddToCart(CartItem item)
    {
        Items.Add(item);
    }
    public void RemoveFromCart(CartItem item)
    {
        Items.Remove(item);
    }
    public int GetTotal()
    {
        return Items.Sum(i => i.TotalPrice);
    }
    public void ClearCart()
    {
        Items.Clear();
    }
     public int GetAllCoffeeNum()
    {
        return Items.Count;
    }
}
}