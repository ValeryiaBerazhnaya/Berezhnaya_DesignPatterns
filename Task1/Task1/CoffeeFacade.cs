namespace Task1
{
    class CoffeeFacade
    {
        private CoffeeMachine coffee = new();
        private MilkFrother milk = new();
        private SugarAdder sugar = new();

        public void MakeCappuccino()
        {
            coffee.Brew();
            milk.Froth();
            sugar.AddSugar();
            Console.WriteLine("Cappuccino is ready!");
        }
    }
}