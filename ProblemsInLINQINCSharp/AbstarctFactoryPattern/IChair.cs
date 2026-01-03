namespace ProblemsInLINQINCSharp.AbstarctFactoryPattern
{
    public interface IChair
    {
        void Sit();
        bool HasArmrests();
        string GetMaterial();
        double GetPrice();
    }

    public interface ISofa
    {
        void Lounge();
        int GetSeatCount();
        string GetStyle();
        double GetPrice();
    }

    public interface ITable
    {
        void PlaceItem(string item);
        int GetLegCount();
        string GetShape();
        double GetPrice();
    }


    public class ModernChair : IChair
    {
        public void Sit()
        {
            Console.WriteLine("Sitting on a modern minimalist chair");
        }

        public bool HasArmrests()
        {
            return false; // Modern chairs often don't have armrests
        }

        public string GetMaterial()
        {
            return "Glass and Steel";
        }

        public double GetPrice()
        {
            return 299.99;
        }
    }

    public class ModernSofa : ISofa
    {
        public void Lounge()
        {
            Console.WriteLine("Lounging on a sleek modern sofa");
        }

        public int GetSeatCount()
        {
            return 3;
        }

        public string GetStyle()
        {
            return "Minimalist";
        }

        public double GetPrice()
        {
            return 899.99;
        }
    }

    public class ModernTable : ITable
    {
        public void PlaceItem(string item)
        {
            Console.WriteLine($"Placing {item} on modern glass table");
        }

        public int GetLegCount()
        {
            return 1; // Modern tables often have single pedestal
        }

        public string GetShape()
        {
            return "Round";
        }

        public double GetPrice()
        {
            return 499.99;
        }
    }

     public interface IFurnitureFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
        ITable CreateTable();
    }

    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }

        public ITable CreateTable()
        {
            return new ModernTable();
        }
    }

    public class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new VictorianChair();
        }

        public ISofa CreateSofa()
        {
            return new VictorianSofa();
        }

        public ITable CreateTable()
        {
            return new VictorianTable();
        }
    }

    public class RusticFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new RusticChair();
        }

        public ISofa CreateSofa()
        {
            return new RusticSofa();
        }

        public ITable CreateTable()
        {
            return new RusticTable();
        }
    }

      public class VictorianTable : ITable
    {
        public void PlaceItem(string item)
        {
            Console.WriteLine($"Placing {item} on ornate Victorian table");
        }

        public int GetLegCount()
        {
            return 4; // Victorian tables have carved legs
        }

        public string GetShape()
        {
            return "Rectangular";
        }

        public double GetPrice()
        {
            return 799.99;
        }
    }

    // Concrete Products for Rustic Furniture
    public class RusticChair : IChair
    {
        public void Sit()
        {
            Console.WriteLine("Sitting on a comfortable rustic chair");
        }

        public bool HasArmrests()
        {
            return true;
        }

        public string GetMaterial()
        {
            return "Reclaimed Wood";
        }

        public double GetPrice()
        {
            return 199.99;
        }
    }

    public class RusticSofa : ISofa
    {
        public void Lounge()
        {
            Console.WriteLine("Lounging on a cozy rustic sofa");
        }

        public int GetSeatCount()
        {
            return 4;
        }

        public string GetStyle()
        {
            return "Country";
        }

        public double GetPrice()
        {
            return 699.99;
        }
    }

    public class RusticTable : ITable
    {
        public void PlaceItem(string item)
        {
            Console.WriteLine($"Placing {item} on sturdy rustic table");
        }

        public int GetLegCount()
        {
            return 4;
        }

        public string GetShape()
        {
            return "Square";
        }

        public double GetPrice()
        {
            return 399.99;
        }
    }


    class FurnitureStore
    {
        private IFurnitureFactory _factory;

        public FurnitureStore(IFurnitureFactory factory)
        {
            _factory = factory;
        }

        public void DisplayCatalog()
        {
            Console.WriteLine("\n=== Furniture Catalog ===");
            
            var chair = _factory.CreateChair();
            var sofa = _factory.CreateSofa();
            var table = _factory.CreateTable();

            Console.WriteLine($"Chair: {chair.GetMaterial()} - ${chair.GetPrice()}");
            Console.WriteLine($"Sofa: {sofa.GetStyle()} ({sofa.GetSeatCount()} seats) - ${sofa.GetPrice()}");
            Console.WriteLine($"Table: {table.GetShape()} ({table.GetLegCount()} legs) - ${table.GetPrice()}");
            
            double total = chair.GetPrice() + sofa.GetPrice() + table.GetPrice();
            Console.WriteLine($"Total Set Price: ${total}");
        }

        public void DemonstrateFurniture()
        {
            Console.WriteLine("\n=== Demonstration ===");
            
            var chair = _factory.CreateChair();
            var sofa = _factory.CreateSofa();
            var table = _factory.CreateTable();

            chair.Sit();
            sofa.Lounge();
            table.PlaceItem("a vase");
            
            Console.WriteLine($"Chair has armrests: {chair.HasArmrests()}");
        }
    }



}