using System;
using System.Threading;

namespace СountdownСlock
{
    public delegate void CountDown(string taskName, int submittedTime);

    public class Timer
    {
        public string Name { get; init; }
        public int AmountTime { get; init; }

        public event EventHandler<TimerEventArgs> CountdownStart;
        public event EventHandler<TimerEventArgs> RemainingSeconds;
        public event EventHandler<TimerEventArgs> CountdownEnded;

        public Timer(string name, int amountTime)
        {
            Name = name;
            AmountTime = amountTime;
        }

        public void Start()
        {
            CountdownStart?.Invoke(this, new TimerEventArgs(Name, AmountTime));

            for (int i = AmountTime - 1; i >= 0; i--)
            {
                Thread.Sleep(1000);
                RemainingSeconds?.Invoke(this, new TimerEventArgs(Name, i));
            }

            CountdownEnded?.Invoke(this, new TimerEventArgs(Name, AmountTime));
        }
    }
}

