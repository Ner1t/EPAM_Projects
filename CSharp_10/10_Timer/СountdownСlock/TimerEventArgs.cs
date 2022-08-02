namespace СountdownСlock
{
    public class TimerEventArgs
    {
        public int SecondsLeft { get; init; }
        public string Name { get; init; }

        public TimerEventArgs(string name, int secondsLeft)
        {
            Name = name;
            SecondsLeft = secondsLeft;
        }
    }
}