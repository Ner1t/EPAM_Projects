using System;

namespace СountdownСlock
{
    public class SubscriberLambdaExpression : ICountDownNotifier
    {
        readonly Timer timer;
        readonly EventHandler<TimerEventArgs> CountdownStartAdapter;
        readonly EventHandler<TimerEventArgs> CountdownEndedAdapter;

        public SubscriberLambdaExpression(Timer timer, CountDown started, Action<string, int> expired)
        {
            this.timer = timer;

            CountdownStartAdapter = (object sender, TimerEventArgs e) =>
            {
              started.Invoke(e.Name, e.SecondsLeft);
            };

            CountdownEndedAdapter = (object sender, TimerEventArgs e) =>
            {
                expired.Invoke(e.Name, e.SecondsLeft);
            };
        }

        readonly EventHandler<TimerEventArgs> Remaining = (object sender, TimerEventArgs e) =>
        {
            Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {e.Name}: {e.SecondsLeft} seconds remaining.");
        };

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
