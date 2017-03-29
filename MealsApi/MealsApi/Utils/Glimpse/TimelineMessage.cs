using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Message;

namespace MealsApi.Utils.Glimpse
{
    public class TimelineMessage : ITimelineMessage
    {
        public TimelineMessage()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public TimeSpan Offset { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }
        public string EventName { get; set; }
        public TimelineCategoryItem EventCategory { get; set; }
        public string EventSubText { get; set; }
    }
}