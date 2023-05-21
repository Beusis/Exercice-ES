using Distributeur_Automatique;

namespace Distributeur_Automatique_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVendingSmarlies()
        {
            VendingMachine vendingMachine = new VendingMachine("Vending Machine 1");
            vendingMachine.AddItem("Smarlies", "A01", 10, 1.60);
            vendingMachine.AddItem("Carampar", "A02", 5, 0.60);
            vendingMachine.AddItem("Avril", "A03", 2, 2.10);
            vendingMachine.AddItem("KokoKola", "A04", 1, 2.95);

            vendingMachine.Insert(3.40);
            Assert.AreEqual("Vending Smarlies.", vendingMachine.Choose("A01"));
            Assert.AreEqual("Your change is 1.8 francs.", vendingMachine.GetChange());
        }

        [TestMethod]
        public void TestVendingAvril()
        {
            VendingMachine vendingMachine = new VendingMachine("Vending Machine 1");
            vendingMachine.AddItem("Smarlies", "A01", 10, 1.60);
            vendingMachine.AddItem("Carampar", "A02", 5, 0.60);
            vendingMachine.AddItem("Avril", "A03", 2, 2.10);
            vendingMachine.AddItem("KokoKola", "A04", 1, 2.95);

            vendingMachine.Insert(2.10);
            Assert.AreEqual("Vending Avril.", vendingMachine.Choose("A03"));
            Assert.AreEqual("Your change is 0 francs.", vendingMachine.GetChange());
            Assert.AreEqual("Your balance is 2.1 francs.", vendingMachine.GetBalance());
        }

        [TestMethod]
        public void TestVendingWithoutMoney()
        {
            VendingMachine vendingMachine = new VendingMachine("Vending Machine 1");
            vendingMachine.AddItem("Smarlies", "A01", 10, 1.60);
            vendingMachine.AddItem("Carampar", "A02", 5, 0.60);
            vendingMachine.AddItem("Avril", "A03", 2, 2.10);
            vendingMachine.AddItem("KokoKola", "A04", 1, 2.95);

            Assert.AreEqual("Not enough money!", vendingMachine.Choose("A01"));
        }

        [TestMethod]
        public void TestVendingMultipleItem()
        {
            VendingMachine vendingMachine = new VendingMachine("Vending Machine 1");
            vendingMachine.AddItem("Smarlies", "A01", 10, 1.60);
            vendingMachine.AddItem("Carampar", "A02", 5, 0.60);
            vendingMachine.AddItem("Avril", "A03", 2, 2.10);
            vendingMachine.AddItem("KokoKola", "A04", 1, 2.95);

            vendingMachine.Insert(1);
            Assert.AreEqual("Not enough money!", vendingMachine.Choose("A01"));
            Assert.AreEqual("Your change is 1 francs.", vendingMachine.GetChange());
            Assert.AreEqual("Vending Carampar.", vendingMachine.Choose("A02"));
            Assert.AreEqual("Your change is 0.4 francs.", vendingMachine.GetChange());
        }

        [TestMethod]
        public void TestVendingInvalidSelection()
        {
            VendingMachine vendingMachine = new VendingMachine("Vending Machine 1");
            vendingMachine.AddItem("Smarlies", "A01", 10, 1.60);
            vendingMachine.AddItem("Carampar", "A02", 5, 0.60);
            vendingMachine.AddItem("Avril", "A03", 2, 2.10);
            vendingMachine.AddItem("KokoKola", "A04", 1, 2.95);

            vendingMachine.Insert(1);
            Assert.AreEqual("Invalid selection!", vendingMachine.Choose("A05"));
        }

        [TestMethod]
        public void TestVendingSoldOut()
        {
            VendingMachine vendingMachine = new VendingMachine("Vending Machine 1");
            vendingMachine.AddItem("Smarlies", "A01", 10, 1.60);
            vendingMachine.AddItem("Carampar", "A02", 5, 0.60);
            vendingMachine.AddItem("Avril", "A03", 2, 2.10);
            vendingMachine.AddItem("KokoKola", "A04", 1, 2.95);

            vendingMachine.Insert(6);
            Assert.AreEqual("Vending KokoKola.", vendingMachine.Choose("A04"));
            Assert.AreEqual("Item KokoKola: Out of stock!", vendingMachine.Choose("A04"));
            Assert.AreEqual("Your change is 3.05 francs.", vendingMachine.GetChange());
        }
    }
}