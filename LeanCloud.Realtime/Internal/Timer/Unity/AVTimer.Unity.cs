﻿using System;
using System.Timers;

namespace LeanCloud.Realtime.Internal
{
    public class AVTimer:IAVTimer
    {
        public AVTimer()
        {
            timer = new Timer();
        }
        Timer timer;

        public bool Enabled
        {
            get
            {
                return timer.Enabled;
            }
            set
            {
                timer.Enabled = value;
            }
        }

        public double Interval
        {
            get
            {
                return timer.Interval;
            }
            set
            {
                timer.Interval = value;
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public event EventHandler<TimerEventArgs> Elapsed
        {
            add
            {
                timer.Elapsed += (object sender, ElapsedEventArgs e) =>
                {
                    value(sender, new TimerEventArgs(e.SignalTime));
                };
            }
            remove
            {
                timer.Elapsed -= (object sender, ElapsedEventArgs e) =>
                {
                    value(sender, new TimerEventArgs(e.SignalTime));
                }; ;
            }
        }
    }
}
