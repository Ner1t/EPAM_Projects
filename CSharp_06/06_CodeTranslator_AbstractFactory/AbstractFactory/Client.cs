
using System;

namespace AbstractFactory
{
    public class Client
    {
        readonly IOnboardElectronics Factory;

        IElectricalSensors productSensors;
        IElectricalRelays productRelays;

        public Client(IOnboardElectronics factory)
        {
            Factory = factory;
        }

        public void GetProducts()
        {
            productSensors = Factory.CreateSensors();
            productRelays = Factory.CreateRelays();
        }

        public void ShowProducts()
        {
            Console.WriteLine(productSensors.ShortDescription());
            Console.WriteLine(productRelays.ShortDescription());
        }
    }
}
