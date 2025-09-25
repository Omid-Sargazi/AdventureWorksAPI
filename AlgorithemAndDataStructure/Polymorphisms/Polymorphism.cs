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


    public class SimplePerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        //- Equals
        //- GetHashCode
        //-ToString
        //- Deconstructor
    }

    public class RunPerson
    {
        public static void Run()
        {
            SimplePerson p1 = new SimplePerson { Name = "Omid", Age = 42 };
            SimplePerson p2 = new SimplePerson { Name = "Omid", Age = 42 };

            var p3 = new Person("Omid", 42);
            var p4 = new Person("Omid", 42);

            Console.WriteLine($"Classes: {p1 == p2}");

            Console.WriteLine($"Records: {p3 == p4}");

            var (name, age) = p3;

            var p5 = p3 with { Age = 20 };
            Console.WriteLine(p3);




        }

        public static void DemonstrateCovariance()
        {
            Func<Dog> getDog = () => new Dog();
            Func<Animal> getAnimal = getDog;

            Animal result = getAnimal();
            Console.WriteLine($"result: {result.GetType().Name}");

            Func<Dog> createDog = () => new Dog { Name = "rex" };


            IEnumerable<Dog> dogs = new List<Dog> { new Dog(), new Dog() };
            IEnumerable<Animal> animals = dogs;

        }

        public static void DemonstrateContravariance()
        {
            Action<Animal> actAnimal = (animal) =>
            {
                Console.WriteLine($"Processing: {animal.GetType().Name}");
            };

            Action<Dog> actDog = actAnimal;
            actDog(new Dog());
        }
    }

    public record Person(string Name, int Age); //only one line;


    public class Animal { }
    public class Dog : Animal {  public string Name{ get; set; }}



}