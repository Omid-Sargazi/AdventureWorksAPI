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


     public class SportsCar : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Driving sports car at high speed!");
        }

        public string GetModel()
        {
            return "Ferrari 488";
        }

        public int GetSeatCount()
        {
            return 2;
        }

        public string GetFuelType()
        {
            return "Premium Gasoline";
        }

        public double CalculateFuelEfficiency(double distance)
        {
            return distance / 8.5; // 8.5 km per liter
        }
    }

    public class SportsMotorcycle : IMotorcycle
    {
        public void Ride()
        {
            Console.WriteLine("Racing sports motorcycle!");
        }

        public string GetModel()
        {
            return "Ducati Panigale";
        }

        public int GetEngineCC()
        {
            return 1103;
        }

        public bool HasStorage()
        {
            return false;
        }

        public double CalculateMileage(double distance)
        {
            return distance / 15.0; // 15 km per liter
        }
    }

    public class SportsBicycle : IBicycle
    {
        public void Pedal()
        {
            Console.WriteLine("Racing on sports bicycle!");
        }

        public string GetModel()
        {
            return "Specialized Tarmac";
        }

        public int GetGearCount()
        {
            return 22;
        }

        public bool HasBasket()
        {
            return false;
        }

        public double CalculateSpeed(double time, double distance)
        {
            return time > 0 ? distance / time * 3.6 : 0; // km/h
        }
    }

    // Concrete Products for Family Vehicles
    public class FamilyCar : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Driving family car safely");
        }

        public string GetModel()
        {
            return "Toyota Camry";
        }

        public int GetSeatCount()
        {
            return 5;
        }

        public string GetFuelType()
        {
            return "Regular Gasoline";
        }

        public double CalculateFuelEfficiency(double distance)
        {
            return distance / 12.5; // 12.5 km per liter
        }
    }

    public class FamilyMotorcycle : IMotorcycle
    {
        public void Ride()
        {
            Console.WriteLine("Riding family motorcycle comfortably");
        }

        public string GetModel()
        {
            return "Honda Gold Wing";
        }

        public int GetEngineCC()
        {
            return 1833;
        }

        public bool HasStorage()
        {
            return true;
        }

        public double CalculateMileage(double distance)
        {
            return distance / 18.0; // 18 km per liter
        }
    }

    public class FamilyBicycle : IBicycle
    {
        public void Pedal()
        {
            Console.WriteLine("Riding family bicycle leisurely");
        }

        public string GetModel()
        {
            return "Schwinn Cruiser";
        }

        public int GetGearCount()
        {
            return 7;
        }

        public bool HasBasket()
        {
            return true;
        }

        public double CalculateSpeed(double time, double distance)
        {
            return time > 0 ? distance / time * 2.5 : 0; // km/h
        }
    }

    // Concrete Products for Eco Vehicles
    public class EcoCar : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Driving eco-friendly electric car");
        }

        public string GetModel()
        {
            return "Tesla Model 3";
        }

        public int GetSeatCount()
        {
            return 5;
        }

        public string GetFuelType()
        {
            return "Electric";
        }

        public double CalculateFuelEfficiency(double distance)
        {
            return distance / 6.0; // 6 km per kWh
        }
    }

    public class EcoMotorcycle : IMotorcycle
    {
        public void Ride()
        {
            Console.WriteLine("Riding electric motorcycle silently");
        }

        public string GetModel()
        {
            return "Zero SR/F";
        }

        public int GetEngineCC()
        {
            return 0; // Electric
        }

        public bool HasStorage()
        {
            return true;
        }

        public double CalculateMileage(double distance)
        {
            return distance / 10.0; // 10 km per kWh
        }
    }

    public class EcoBicycle : IBicycle
    {
        public void Pedal()
        {
            Console.WriteLine("Riding eco-friendly bicycle");
        }

        public string GetModel()
        {
            return "Trek FX";
        }

        public int GetGearCount()
        {
            return 21;
        }

        public bool HasBasket()
        {
            return true;
        }

        public double CalculateSpeed(double time, double distance)
        {
            return time > 0 ? distance / time * 3.0 : 0; // km/h
        }
    }


    public interface IVehicleFactory
    {
        ICar CreateCar();
        IMotorcycle CreateMotorcycle();
        IBicycle CreateBicycle();
    }
}