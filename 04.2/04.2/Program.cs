using System;
using System.Threading;

namespace _04._2
{
    //定义委托
    public delegate void ClockHandler(object sender, int Time);
    class Clock
    {
        public event ClockHandler Tick;
        public event ClockHandler Alarm;
        //时间
        public int Time { get; set; }
        //定义运行函数
        public void run()
        {
            Console.WriteLine("闹钟开始运行！");
            for (Time = 1; Time <= 100; Time++)
            {
                Tick(this, Time);
                if (Time % 10 == 0)
                    Alarm(this, Time);
                Thread.Sleep(1);
            }
            Console.WriteLine("clock is power off.");
        }
    }
    //用户
    class User
    {
        public Clock clock;
        public User(Clock clock)
        {
            clock.Alarm += OnAlarm;
            clock.Tick += OnTick;
        }

        public void OnAlarm(object sneder, int Time)
        {
            Console.WriteLine(Time + " di~di~");
        }

        public void OnTick(object sender, int Time)
        {
            Console.WriteLine(Time + " dida~ ");
        }
    }
    delegate int func(int u);
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            User a = new User(clock);
            User b = new User(clock);
            clock.run();
        }
    }
}
