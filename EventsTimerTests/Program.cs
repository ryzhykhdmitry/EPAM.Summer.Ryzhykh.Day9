using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsTimer;

namespace EventsTimerTests
{
    class Program
    {
        #region User1
        public class User1
        {
            public User1(Timer timer)
            {
                Register(timer);
            }
            public User1()
            {

            }
            private void WakeUp(Object sender, TimerEventArgs message)
            {
                Console.WriteLine($"Good morning. I'm John");
                Console.WriteLine($"Timer says: Title - {message?.Title}, Text - {message?.Text}");

                Console.WriteLine(new string('-', 10));
            }
            public void Unregister(Timer timer)
            {
                if (ReferenceEquals(timer, null)) throw new ArgumentNullException();
                timer.Event -= WakeUp;
            }
            public void Register(Timer timer)
            {
                if (ReferenceEquals(timer, null)) throw new ArgumentNullException();
                timer.Event += WakeUp;
            }
        }
        #endregion

        #region User2
        public class User2
        {
            public User2(Timer timer)
            {
                Register(timer);
            }
            public User2()
            {

            }
            private void WakeUp(Object sender, TimerEventArgs message)
            {
                Console.WriteLine($"Hey! I'm Jake");
                Console.WriteLine($"Timer says: Title - {message?.Title}, Text - {message?.Text}");

                Console.WriteLine(new string('-', 10));
            }
            public void Unregister(Timer timer)
            {
                if (ReferenceEquals(timer, null)) throw new ArgumentNullException();
                timer.Event -= WakeUp;
            }
            public void Register(Timer timer)
            {
                if (ReferenceEquals(timer, null)) throw new ArgumentNullException();
                timer.Event += WakeUp;
            }
        } 
        #endregion

        static void Main(string[] args)
        {
            Timer timer1 = new Timer(3000);  timer1.SetEventData(new TimerEventArgs("Hello","world"));
            User1 person1 = new User1();
            User2 person2 = new User2(timer1);
            person1.Register(timer1);            
            timer1.StartTimer();
            Console.ReadKey();
            Console.WriteLine("John stoped his registration ");
            person1.Unregister(timer1);            
            Console.ReadKey();
        }
    }
}
