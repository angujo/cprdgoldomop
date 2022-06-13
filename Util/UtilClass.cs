using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Util
{
    public static class UtilClass
    {
        public static object MissValue(Type type, object value = null)
        {
            if (null != value && !DBNull.Value.Equals(value)) return value;
            if (type == typeof(string)) return Consts.TUPLE_MISS_STR;
            if (type.IsNumber()) return int.MinValue;
            if (type == typeof(DateTime)) return DateTime.MinValue;
            return null;
        }

        public static T[] Prepend<T>(this T[] items, params T[] args)
        {
            return args.Reverse().Aggregate(new List<T>(items), (current, rarg) => current.Prepend(rarg).ToList())
                       .ToArray();
        }

        public static Action<T> Debounce<T>(this Action<T> func, int milliseconds = 300)
        {
            CancellationTokenSource cancelTokenSource = null;

            return arg =>
            {
                cancelTokenSource?.Cancel();
                cancelTokenSource = new CancellationTokenSource();

                Task.Delay(milliseconds, cancelTokenSource.Token)
                    .ContinueWith(t =>
                    {
                        if (t.IsCompleted)
                        {
                            func(arg);
                        }
                    }, TaskScheduler.Default);
            };
        }

        public static Action Debounce(this Action func, int milliseconds = 300)
        {
            CancellationTokenSource cancelTokenSource = null;

            return () =>
            {
                cancelTokenSource?.Cancel();
                cancelTokenSource = new CancellationTokenSource();

                Task.Delay(milliseconds, cancelTokenSource.Token)
                    .ContinueWith(t =>
                    {
                        if (t.IsCompleted)
                        {
                            func();
                        }
                    }, TaskScheduler.Default);
            };
        }
    }
}