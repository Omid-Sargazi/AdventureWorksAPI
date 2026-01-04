namespace ProblemsInLINQINCSharp.AbstarctFactoryPattern
{
   public interface IVehicleFactory2
    {
        ICar CreateCar();
        IMotorcycle CreateMotorcycle();
    }

    public interface ICar2
    {
        string GetDescription();
        string Drive();
    }

    public interface IMotorcycle2
    {
        string GetDescription();
        string Ride();
    }

    // کارخانه وسایل نقلیه اقتصادی
    public class EconomyVehicleFactory : IVehicleFactory2
    {
        public ICar CreateCar() => new EconomyCar();
        public IMotorcycle CreateMotorcycle() => new EconomyMotorcycle();
    }

    // کارخانه وسایل نقلیه لوکس
    public class LuxuryVehicleFactory : IVehicleFactory2
    {
        public ICar CreateCar() => new LuxuryCar();
        public IMotorcycle CreateMotorcycle() => new LuxuryMotorcycle();
    }

    // ماشین اقتصادی
    public class EconomyCar : ICar2
    {
        public string GetDescription() => "ماشین اقتصادی با مصرف سوخت پایین";
        public string Drive() => "در حال رانندگی با ماشین اقتصادی...";
    }

    // ماشین لوکس
    public class LuxuryCar : ICar2
    {
        public string GetDescription() => "ماشین لوکس با امکانات پیشرفته";
        public string Drive() => "در حال رانندگی با ماشین لوکس...";
    }

    // موتورسیکلت اقتصادی
    public class EconomyMotorcycle : IMotorcycle2
    {
        public string GetDescription() => "موتورسیکلت اقتصادی برای شهر";
        public string Ride() => "در حال راندن موتورسیکلت اقتصادی...";
    }

    // موتورسیکلت لوکس
    public class LuxuryMotorcycle : IMotorcycle2
    {
        public string GetDescription() => "موتورسیکلت اسپورت با قدرت بالا";
        public string Ride() => "در حال راندن موتورسیکلت اسپورت...";
    }
}