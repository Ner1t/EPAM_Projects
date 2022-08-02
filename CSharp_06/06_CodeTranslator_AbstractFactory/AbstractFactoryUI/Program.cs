using AbstractFactory;

namespace AbstractFactoryUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IOnboardElectronics analog = new AssemblyAnalogComponents();
            IOnboardElectronics digital = new AssemblyDigitalComponents();

            Client first = new(analog);
            Client second = new(digital);

            first.GetProducts();
            second.GetProducts();

            first.ShowProducts();
            System.Console.WriteLine();
            second.ShowProducts();
        }
    }
}
