using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTPController
{
    public class Timing
    {
        // private int _interval;
        private System.Timers.Timer _timer;
        private DateTime _startTime;
        public FTPModel.Delegate.OnTimingStart _onTimingStart = null;
        /// <summary>
        /// Timing构造函数
        /// </summary>
        /// <param name="interval">计时器间隔</param>
        /// <param name="startTime">计时器事件启动时间</param>
        public Timing(double interval, DateTime startTime)
        {
            this._timer = new System.Timers.Timer(interval);
            this._timer.Elapsed += _timer_Elapsed;
            this._startTime = startTime;
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this._startTime.Hour == DateTime.Now.Hour && this._startTime.Minute == DateTime.Now.Minute)
            {
                if (this._onTimingStart != null)
                {
                    this._onTimingStart();
                }
            }
        }
        public void Start()
        {
            this._timer.Start();
        }
        public void Stop()
        {
            this._timer.Stop();
        }

    }
}
