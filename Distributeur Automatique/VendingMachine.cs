namespace Distributeur_Automatique
{
    public class VendingMachine
    {
        public string name;
        public string code;
        public int quantity;
        public double price;
        public double balance;
        public double amount;
        public List<Item> items;
        public List<Item> selection;
        public List<VendingMachine> vendingMachines;

        public VendingMachine(string name)
        {
            this.name = name;
            vendingMachines = new List<VendingMachine>
            {
                this
            };
            items = new List<Item>();
            selection = new List<Item>();
        }

        public void AddItem(string name, string code, int quantity, double price)
        {            
            Item item = new Item(name, code, quantity, price);
            items.Add(item);
        }

        public void Insert(double amount)
        {
            if (amount > 0)
            {
                Console.WriteLine("You have inserted " + amount + " francs.");
                this.amount += amount;
            }
            else
            {
                Console.WriteLine("Please insert a valid amount.");
            }            
        }

        public string Choose(string code)
        {
            this.code = code;
            foreach (Item item in items)
            {
                if (item.quantity > 0 && item.code == this.code)
                {
                    if (item.price <= amount)
                    {
                        Console.WriteLine("Vending " + item.name + ".");
                        balance += amount;
                        amount -= item.price;
                        item.quantity -= 1;
                        selection.Add(item);
                        return "Vending " + item.name + ".";
                    }
                    else
                    {
                        Console.WriteLine("Not enough money!");
                        return "Not enough money!";
                    }
                }
                else if (item.quantity == 0 && item.code == this.code)
                {
                    Console.WriteLine("Item " + item.name + ": Out of stock!");
                    return "Item " + item.name + ": Out of stock!";
                }
            }

            Console.WriteLine("Invalid selection!");
            return "Invalid selection!";
        }

        public string GetChange()
        {
            Console.WriteLine("Your change is " + Math.Round(amount, 2) + " francs.");
            return "Your change is " + Math.Round(amount, 2) + " francs.";
        }

        public string GetBalance()
        {
            Console.WriteLine("Your balance is " + Math.Round(balance, 2) + " francs.");
            return "Your balance is " + Math.Round(balance, 2) + " francs.";
        }
    }
}