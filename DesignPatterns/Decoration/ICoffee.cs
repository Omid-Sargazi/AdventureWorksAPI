namespace DesignPatterns.Decoration
{
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    public class SimpleCofee : ICoffee
    {
        public double GetCost()
        {
            return 0.5;
        }

        public string GetDescription()
        {
            return "simple Coffee";
        }
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        protected readonly ICoffee _coffee;
        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee =coffee;
        }
        public virtual double GetCost() => _coffee.GetCost();

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }
    }
}