using System;
using СountdownСlock;

namespace TimerProcessor
{
    class Program
    {
        private static void JobTimeStarted(string taskName, int submittedTime)
        {
            Console.WriteLine($"[{DateTime.Now.Second}]:Timer: Task {taskName} has started for {submittedTime} seconds.");
        }

        private static void JobTimeExpired(string taskName, int submittedTime)
        {
            Console.WriteLine($"[{DateTime.Now.Second}]:Timer: Task {taskName} has finished.");
        }

        static void Main(string[] args)
        {
            Timer[] timer = new Timer[3] {
                new Timer("Чтение задания", 1),
                new Timer("Выполнение задания", 2),
                new Timer("Проверка задания перед отправкой", 5) };

            ICountDownNotifier[] subscribers = new ICountDownNotifier[3]
            {
                new SubscriberClassicMethod(timer[0], JobTimeStarted, JobTimeExpired),
                new SubscriberAnonymousDelegate(timer[1], JobTimeStarted, JobTimeExpired),
                new SubscriberLambdaExpression(timer[2], JobTimeStarted, JobTimeExpired)
            };

            for (int i = 0; i < subscribers.Length; i++)
            {
                subscribers[i].Init();
                subscribers[i].Run();
                subscribers[i].Unsubscribe();
                Console.WriteLine();
            }
        }
    }
}
