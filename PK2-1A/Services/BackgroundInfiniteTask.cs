using cip_blue.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    internal class BackgroundInfiniteTask : IBackgroundTaskStarterService
    {
        private readonly Action _action;
        private readonly PeriodicTimer _timer;
        private readonly CancellationTokenSource _cts;
        public BackgroundInfiniteTask(Action action, TimeSpan interval, CancellationTokenSource cts)
        {
            _action = action;
            _timer = new PeriodicTimer(interval);
            _cts = cts;
        }

        private async Task DoWorkAsync()
        {
            try
            {
                _action();
                while (await _timer.WaitForNextTickAsync(_cts.Token))
                {
                    _action();
                }

            }
            catch (OperationCanceledException)
            {

            }
        }
        public void Start()
        {
            Task.Run(DoWorkAsync);
        }

        public void Stop()
        {
            if (_action is null)
            {
                return;
            }

            _cts.Cancel();
            _cts.Dispose();
        }
    }
}
