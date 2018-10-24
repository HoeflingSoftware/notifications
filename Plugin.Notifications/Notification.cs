﻿using System;


namespace Plugin.Notifications
{

    public class Notification
    {
        public static string DefaultTitle { get; set; }
        public static string DefaultSound { get; set; }
        public static string AndroidDefaultChannel { get; set; } = "pluginnotifications";

        public string Id { get; set; }
        public string Title { get; set; } = DefaultTitle;
        public string Message { get; set; }

        public int AndroidSmallIconResource { get; set; }
        public static string AndroidChannel { get; set; } = AndroidDefaultChannel;
        //public static string ChannelDescription { get; set; }

        /// <summary>
        /// Play a sound from the native platform
        /// </summary>
        public string Sound { get; set; } = DefaultSound;


        /// <summary>
        /// The notification trigger to use - leaving this null will use a non-repeating immediate trigger
        /// </summary>
        public INotificationTrigger Trigger { get; set; }


        /// <summary>
        /// Additional data you can add to your notification
        /// </summary>
        public string Payload { get; set; }


        /// <summary>
        /// Only works with Android
        /// </summary>
        public bool Vibrate { get; set; }
    }
}