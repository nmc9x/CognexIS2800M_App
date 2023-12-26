using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OCR_Camera_Printer.Controller
{
    public class AsyncTimer
    {
        private readonly Func<Task> _action;
        private readonly int _period;
        private readonly CancellationToken _cancellationToken;

        public AsyncTimer(Func<Task> action, int period, CancellationToken cancellationToken)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _period = period;
            _cancellationToken = cancellationToken;
        }

        public async Task StartAsync()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                await _action();

                try
                {
                    await Task.Delay(_period, _cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    break; 
                }
            }
        }
    }
}
