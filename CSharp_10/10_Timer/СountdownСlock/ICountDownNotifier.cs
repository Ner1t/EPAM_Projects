namespace СountdownСlock
{
    public interface ICountDownNotifier
    {
        void Init();
        void Run();
        void Unsubscribe();
    }
}
