using System;

namespace TestMonkeys.CoreUI.Util
{
    public class Wait
    {
        public static void UntilSucceeds(Action action, TimeSpan timeout)
        {
            DateTime start = DateTime.Now;
            Exception failure = null;
            while (DateTime.Now - start < timeout)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    failure = e;
                }
            }
            if (failure != null)
                throw failure;
            throw new Exception("Timeout reached");
        }

        public static T Until<T>(Func<T> func, TimeSpan timeout)
        {
            DateTime start = DateTime.Now;
            Exception failure = null;
            while (DateTime.Now - start < timeout)
            {
                try
                {
                    T result = func.Invoke();
                    return result;
                }
                catch (Exception e)
                {
                    failure = e;
                }
            }
            if (failure != null)
                throw failure;
            throw new Exception("Timeout reached");
        }

        public static void UntilTrue(Func<bool> func, TimeSpan timeout)
        {
            DateTime start = DateTime.Now;
            Exception failure = null;
            while (DateTime.Now - start < timeout)
            {
                try
                {
                    bool result = func.Invoke();
                    if (result)
                        return;
                }
                catch (Exception e)
                {
                    failure = e;
                }
            }
            if (failure != null)
                throw failure;
            throw new Exception("Timeout reached and still no success");
        }
    }
}