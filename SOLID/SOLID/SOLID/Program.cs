namespace SOLID
{
    public interface IBird
    {
        void Sing();
        void Dance();
        void SearchForSpouse();
        void ProduceEgg();
        void DefendEgg();
    }

    public interface IFlyable
    {
        void Fly();
    }

    public interface IMovable
    {
        void Walk();
    }

    public class Sparrow : IBird, IFlyable, IMovable
    {
        public void Sing() => Console.WriteLine("Sparrow sings");
        public void Dance() => Console.WriteLine("Sparrow dances");
        public void SearchForSpouse() => Console.WriteLine("Sparrow finds spouse");
        public void ProduceEgg() => Console.WriteLine("Sparrow lays egg");
        public void DefendEgg() => Console.WriteLine("Sparrow defends egg");
        public void Walk() => Console.WriteLine("Sparrow walks");
        public void Fly() => Console.WriteLine("Sparrow flies");
    }

    public class Pinguin : IBird, IMovable
    {
        public void Sing() => Console.WriteLine("Pinguin sings");
        public void Dance() => Console.WriteLine("Pinguin dances");
        public void SearchForSpouse() => Console.WriteLine("Pinguin finds spouse");
        public void ProduceEgg() => Console.WriteLine("Pinguin lays egg");
        public void DefendEgg() => Console.WriteLine("Pinguin defends egg");
        public void Walk() => Console.WriteLine("Pinguin walks");
    }

    public interface IBirdFactory
    {
        IBird CreateBird(string type);
    }

    public class SimpleBirdFactory : IBirdFactory
    {
        public IBird CreateBird(string type)
        {
            return type switch
            {
                "Sparrow" => new Sparrow(),
                "Pinguin" => new Pinguin(),
                _ => throw new ArgumentException("Unknown bird type")
            };
        }
    }

    public class BirdActionService
    {
        public void HandleMoves(IMovable bird)
        {
            bird.Walk();
            if (bird is IFlyable flyingBird)
            {
                flyingBird.Fly();
            }
        }

        public void HandleMultiplication(IBird bird)
        {
            bird.SearchForSpouse();
            bird.Sing();
            bird.Dance();
        }

        public void HandleChildRaising(IBird bird)
        {
            bird.ProduceEgg();
            bird.DefendEgg();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBirdFactory factory = new SimpleBirdFactory();
            var actionService = new BirdActionService();

            var birds = new List<IBird>
            {
                factory.CreateBird("Sparrow"),
                factory.CreateBird("Pinguin")
            };

            foreach (var bird in birds)
            {
                Console.WriteLine("--- Handling bird: " + bird.GetType().Name + " ---");
                if (bird is IMovable movable) actionService.HandleMoves(movable);
                actionService.HandleMultiplication(bird);
                actionService.HandleChildRaising(bird);
            }
        }
    }
}
