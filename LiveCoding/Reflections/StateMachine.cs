namespace LiveCoding.Reflections
{
    public enum TrafficLightState
    {
        Red,
        Yellow,
        Green,
    }
    public class TrafficLight
    {
        private TrafficLightState _currentState = TrafficLightState.Red;

        public void ChangeState()
        {
            switch (_currentState)
            {
                case TrafficLightState.Red:
                    _currentState = TrafficLightState.Green;
                    Console.WriteLine("Move");
                    break;

                case TrafficLightState.Green:
                    _currentState = TrafficLightState.Yellow;
                    Console.WriteLine("Caution");
                    break;

                case TrafficLightState.Yellow:
                    _currentState = TrafficLightState.Red;
                    Console.WriteLine("Stop");
                    break;
            }
        }
    }

    public class ClientStateMachin
    {
        public static void Run()
        {
            var trffic = new TrafficLight();
            trffic.ChangeState();
            trffic.ChangeState();
            trffic.ChangeState();
        }
    }

   
}