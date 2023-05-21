namespace Distributeur_Automatique
{
    public class Item : VendingMachine
    {
        public Item(string name, string code, int quantity, double price) : base(name)
        {
            base.name = name;
            this.code = code;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
