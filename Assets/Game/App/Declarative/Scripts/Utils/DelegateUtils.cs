using System;

namespace Declarative
{
    public static class DelegateUtils
    {
        public static void Dispose(ref System.Action action)
        {
            if (action == null)
            {
                return;
            }

            var delegates = action.GetInvocationList();
            foreach (var @delegate in delegates)
            {
                action -= (Action) @delegate;
            }

            action = null;
        }

        public static void Dispose<T>(ref System.Action<T> action)
        {
            if (action == null)
            {
                return;
            }

            var delegates = action.GetInvocationList();
            foreach (var @delegate in delegates)
            {
                action -= (Action<T>) @delegate;
            }

            action = null;
        }
    }
}