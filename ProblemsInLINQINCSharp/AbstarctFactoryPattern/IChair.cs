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

}