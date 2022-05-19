using System.Threading;
using System.Threading.Tasks;

namespace Util
{
    public static class Runner
    {
        private static CancellationTokenSource cancellation = new CancellationTokenSource();

        public static CancellationTokenSource TokenSource => cancellation;
        public static CancellationToken       Token       => cancellation.Token;

        public static ParallelOptions ParallelOptions => new ParallelOptions {CancellationToken = Token};
    }
}