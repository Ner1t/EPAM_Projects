namespace AbstractFactory
{
    public class AssemblyAnalogComponents : IOnboardElectronics
    {
        public IElectricalSensors CreateSensors()
        {
            return new AnalogSensors();
        }

        public IElectricalRelays CreateRelays()
        {
            return new AnalogRelays();
        }


    }
}
