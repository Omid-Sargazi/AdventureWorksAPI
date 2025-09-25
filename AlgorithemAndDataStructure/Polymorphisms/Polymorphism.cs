namespace AlgorithemAndDataStructure.Polymorphisms
{
    public class RemoteControl
    {
        public virtual void PowerButton()
        {
            Console.WriteLine("On and Off");
        }
    }

    public class TVRemote : RemoteControl
    {
        public override void PowerButton()
        {
            Console.WriteLine("Tv on/off");
        }
    }

    public class ACRemote : RemoteControl
    {
        public override void PowerButton()
        {
            Console.WriteLine("AC on/off");
        }
    }


    public class Base
    {
        public void Method1() => Console.WriteLine($"Base.Method1");
        public virtual void Method2() => Console.WriteLine($"Base.Method2");
    }

    public class Drived : Base
    {
        public new void Method1() => Console.WriteLine("Method 1 after overriding.");
        public override void Method2()
        {
            Console.WriteLine($"Method 2 after overriging.");
        }
    }
}