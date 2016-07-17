using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EventsTimer
{
    /// <summary>
    /// Event data.
    /// </summary>
    public sealed class TimerEventArgs : EventArgs
    {
        private readonly string title;
        private readonly string text;

        public TimerEventArgs(string title, string text)
        {
            this.title = title;
            this.text = text;
        }

        public string Title { get { return title; } }
        public string Text { get { return text; } }        
    }

    /// <summary>
    /// Allows to make timer with event.
    /// </summary>
    public class Timer
    {
        private TimerEventArgs eventData;
        private System.Timers.Timer aTimer; 
        public event EventHandler<TimerEventArgs> Event = delegate {};

        /// <summary>
        /// Create timer.
        /// </summary>
        /// <param name="time">Time before event.</param>
        /// <param name="data">Data.</param>
        /// <param name="repeat">Allows to set, will the event repeat or not.</param>
        public Timer(int time = 2000, TimerEventArgs data = null, bool repeat = true)
        {
            aTimer = new System.Timers.Timer(time);
            aTimer.AutoReset = repeat;
            aTimer.Elapsed += TimerEvent;
            eventData = data;
        }

        /// <summary>
        /// Start event timer.
        /// </summary>
        public void StartTimer()
        {
            aTimer.Enabled = true;
        }
        
        /// <summary>
        /// Stop event timer.
        /// </summary>
        public void StopTimer()
        {
            aTimer.Enabled = false;
        }


        protected virtual void OnEvent(TimerEventArgs e)
        {            
            EventHandler<TimerEventArgs> temp = Event;
           
            if (temp != null)
            {                
                temp(this, e);
            }
        }

        public void TimerEvent(Object source, ElapsedEventArgs e)
        {
            OnEvent(eventData);
        }

        /// <summary>
        /// Allows to set event data.
        /// </summary>
        /// <param name="e"></param>
        public void SetEventData(TimerEventArgs e)
        {
            eventData = e;
        }
    }
}
