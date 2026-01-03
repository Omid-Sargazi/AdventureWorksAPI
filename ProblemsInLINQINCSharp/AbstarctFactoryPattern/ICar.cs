namespace ProblemsInLINQINCSharp.AbstarctFactoryPattern
{
     public interface ICar
    {
        void Drive();
        string GetModel();
        int GetSeatCount();
        string GetFuelType();
        double CalculateFuelEfficiency(double distance);
    }

    public interface IMotorcycle
    {
        void Ride();
        string GetModel();
        int GetEngineCC();
        bool HasStorage();
        double CalculateMileage(double distance);
    }

    public interface IBicycle
    {
        void Pedal();
        string GetModel();
        int GetGearCount();
        bool HasBasket();
        double CalculateSpeed(double time, double distance);
    }
}