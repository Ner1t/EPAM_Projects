namespace AbstractFactory
{
    public interface IOnboardElectronics
    {
        IElectricalSensors CreateSensors();
        IElectricalRelays CreateRelays();
    }
}
