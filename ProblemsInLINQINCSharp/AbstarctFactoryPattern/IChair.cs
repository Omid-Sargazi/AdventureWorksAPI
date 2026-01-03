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
}