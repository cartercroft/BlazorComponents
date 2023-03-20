using Microsoft.Extensions.Options;
using System.Timers;

namespace CroftBlazorComponents.Services
{
    public class ToastService : IDisposable
    {
        public event Action<string, ToastLevel>? OnShow;
        public event Action? OnHide;
        private int Interval;
        private System.Timers.Timer? Countdown;
        const int __DEFAULTINTERVAL__ = 5000;
        public ToastService()
        {
            Interval = __DEFAULTINTERVAL__;
        }
        public ToastService(int interval)
        {
            Interval = interval;
        }

        public void ShowToast(string message, ToastLevel level)
        {
            OnShow?.Invoke(message, level);
            StartCountdown();
        }
        public void ShowToast(string message, ToastLevel level, int millis)
        {
            OnShow?.Invoke(message, level);
            StartCountdown(millis);
        }

        private void StartCountdown()
        {
            SetCountdown();

            if (Countdown!.Enabled)
            {
                Countdown.Stop();
                Countdown.Start();
            }
            else
            {
                Countdown!.Start();
            }
        }
        private void StartCountdown(int millis)
        {
            SetCountdown(millis);

            if (Countdown!.Enabled)
            {
                Countdown.Stop();
                Countdown.Start();
            }
            else
            {
                Countdown!.Start();
            }
        }

        private void SetCountdown()
        {
            Countdown = new System.Timers.Timer(Interval);
            Countdown.Elapsed += HideToast;
            Countdown.AutoReset = false;
        }

        private void SetCountdown(int millis)
        {
            Countdown = new System.Timers.Timer(millis);
            Countdown.Elapsed += HideToast;
            Countdown.AutoReset = false;
        }
        private void HideToast(object? source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }


        public void Dispose()
            => Countdown?.Dispose();
    }
    public enum ToastLevel
    {
        Info,
        Warning,
        Success,
        Error
    }
}
