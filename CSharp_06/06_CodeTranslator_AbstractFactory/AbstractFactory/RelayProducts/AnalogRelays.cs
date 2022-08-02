namespace AbstractFactory
{
    public class AnalogRelays : IElectricalRelays
    {
        public string ShortDescription()
        {
            return "Made ANALOG relay";
        }
    }
}
