using Android.OS;

namespace Plugin.Notifications
{
    public class AlarmBinder : Binder
    {
        readonly AlarmService _service;

        public AlarmBinder(AlarmService service)
        {
            _service = service;
        }

        public AlarmService GetService()
        {
            return _service;
        }
    }
}
