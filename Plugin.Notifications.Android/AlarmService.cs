using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;

namespace Plugin.Notifications
{
    [Service(Enabled = true, Label = "Notification Service")]
    [IntentFilter(new [] { "com.hoeflingsoftware.earniejr.AlarmService" })]
    public class AlarmService : Service
    {
        public const string BROADCAST_FILTER = "com.hoeflingsoftware.earniejr.Intent.Action.LocalNotification";
        private AlarmBroadcastReceiver receiver;
        public AlarmService()
        {
            receiver = new AlarmBroadcastReceiver();
            RegisterReceiver(receiver, new IntentFilter(BROADCAST_FILTER));
        }

        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            var binder = new AlarmBinder(this);
            return binder;
        }

        [BroadcastReceiver(Enabled = true, Label = "Notifications Broadcast Receiver")]
        [IntentFilter(new[] { BROADCAST_FILTER })]
        public class AlarmBroadcastReceiver : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                var notificationId = intent.NotificationId();
                var notification = Services.Repository.GetById(notificationId);
                if (notification == null)
                    return;

                Services.Repository.Delete(notificationId);

                // resend without schedule so it goes through normal mechanism
                notification.When = null;
                notification.Date = null;
                CrossNotifications.Current.Send(notification);
            }
        }
    }
}