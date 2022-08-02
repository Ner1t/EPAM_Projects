using System;

namespace СountdownСlock
{
    public class SubscriberClassicMethod : ICountDownNotifier
    {
        readonly Timer timer;
        readonly CountDown started;
        readonly Action<string, int> expired;

        public SubscriberClassicMethod(Timer timer, CountDown started, Action<string, int> expired)
        {
            this.timer = timer;
            this.started = started;
            this.expired = expired;
        }

        public void CountdownStartAdapter(object sender, TimerEventArgs e)
        {
            started.Invoke(e.Name, e.SecondsLeft);
        }

        public void CountdownEndedAdapter(object sender, TimerEventArgs e)
        {
            expired.Invoke(e.Name, e.SecondsLeft);
        }

        private static void Remaining(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {e.Name}: {e.SecondsLeft} seconds remaining.");
        }

        public void Init()
        {
            timer.CountdownStart += CountdownStartAdapter;
            timer.RemainingSeconds += Remaining;
            timer.CountdownEnded += CountdownEndedAdapter;
        }

        public void Run()
        {
            timer.Start();
        }

        public void Unsubscribe()
        {
            timer.CountdownStart -= CountdownStartAdapter;
            timer.RemainingSeconds -= Remaining;
            timer.CountdownEnded -= CountdownEndedAdapter;
        }
    }
}
