using System.Threading;

namespace Util
{
    public class CancelTokenSource : CancellationTokenSource
    {
        public bool IsDisposed { get; private set; }

        public new void Dispose()
        {
            base.Dispose();
            IsDisposed = true;
        }
    }
}