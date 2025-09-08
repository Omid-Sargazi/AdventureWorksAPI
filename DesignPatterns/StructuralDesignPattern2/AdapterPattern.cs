namespace DesignPatterns.StructuralDesignPattern2
{
    public class AdapterPattern
    {
        public interface ITarget
        {
            string GetRequest();
        }

        public class OldSystem
        {
            public string GetOldRequest()
            {
                return "Old Message From System.";
            }
        }

        public class NewSystem : ITarget
        {
            private readonly OldSystem _oldSystem;
            public NewSystem(OldSystem oldSystem)
            {
                _oldSystem = oldSystem;
            }
            public string GetRequest()
            {
               return _oldSystem.GetOldRequest() +"New System";
            }
        }
    }
}