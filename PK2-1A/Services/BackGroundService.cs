using System;
using System.ComponentModel;
using System.Threading;
using NLog;

namespace cip_blue.Services
{
    public interface IBackgroundService
    {
        //AsyncOperation ChangeVariable { get; set; }
        void Start();
        void Stop();
    }

    public abstract class BackgroundService : IBackgroundService, IDisposable
    {
        //private readonly Thread mainThread = null;

        private readonly Thread mainThread = null;

        protected volatile bool cancelThread;
        //protected ILoggerFacade logger;
        private Logger logger = LogManager.GetCurrentClassLogger();

        protected AsyncOperation ChangeVariable;

        //AsyncOperation IBackgroundService.ChangeVariable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public BackgroundService()
        {
            ChangeVariable = AsyncOperationManager.CreateOperation(null);

            mainThread = new Thread(new ThreadStart(Execute));
            mainThread.IsBackground = true;

        }

        protected abstract void Execute();

        public virtual void Start()
        {
            if (!mainThread.IsAlive)
                mainThread.Start();
            //Task.Run(Execute);
        }

        public virtual void Stop()
        {
            if (mainThread.IsAlive)
            {
                cancelThread = true;
                while (mainThread.ThreadState != ThreadState.Stopped) ;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (mainThread != null)
                mainThread.Join();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}