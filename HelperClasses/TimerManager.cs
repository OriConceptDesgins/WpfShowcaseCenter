using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfShowcaseCenter.HelperClasses
{
    internal class TimerManager
    {
        private static readonly Lazy<TimerManager> _instance = new Lazy<TimerManager>(() => new TimerManager());
        private DispatcherTimer? _timer;

        public static TimerManager Instance => _instance.Value;

        public void StartTimer(TimeSpan interval, Action tickCallback)
        {
            _timer = new DispatcherTimer { Interval = interval };
            _timer.Tick += (sender, e) => tickCallback.Invoke();
            _timer.Start();
        }

        public void StopTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
            }
        }
    }
}
