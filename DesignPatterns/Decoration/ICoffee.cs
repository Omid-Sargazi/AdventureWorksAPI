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
            _coffee = coffee;
        }
        public virtual double GetCost() => _coffee.GetCost();

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + "milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.6;
        }
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + "Sugar";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.2;
        }
    }
}