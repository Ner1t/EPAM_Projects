namespace AbstractFactory
{
    public class AssemblyDigitalComponents : IOnboardElectronics
    {
        public IElectricalSensors CreateSensors()
        {
            return new DigitalSensors();
        }

        public IElectricalRelays CreateRelays()
        {
            return new DigitalRelays();
        }


    }
}
