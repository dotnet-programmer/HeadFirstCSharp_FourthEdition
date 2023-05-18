using Automat;

VendingMachine vendingMachine = new AnimalFeedVendingMachine();
Console.WriteLine(vendingMachine.Dispense(2.00M));
//vendingMachine.CheckAmount(1F);