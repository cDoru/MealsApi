using System;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Message;

namespace MealsApi.Utils.Glimpse
{
    public class OngoingCapture : IDisposable
    {
        public static OngoingCapture Empty()
        {
            return new NullOngoingCapture();
        }

        private OngoingCapture()
        {
        }

        public OngoingCapture(IExecutionTimer executionTimer, IMessageBroker messageBroker, string eventName, string eventSubText, TimelineCategoryItem category, ITimelineMessage message)
        {
            Offset = executionTimer.Start();
            ExecutionTimer = executionTimer;
            Message = message.AsTimelineMessage(eventName, category, eventSubText);
            MessageBroker = messageBroker;
        }

        private ITimelineMessage Message { get; set; }

        private TimeSpan Offset { get; set; }

        private IExecutionTimer ExecutionTimer { get; set; }

        private IMessageBroker MessageBroker { get; set; }

        public virtual void Stop()
        {
            var timerResult = ExecutionTimer.Stop(Offset);

            MessageBroker.Publish(Message.AsTimedMessage(timerResult));
        }

        public void Dispose()
        {
            Stop();
        }

        private class NullOngoingCapture : OngoingCapture
        {
            public override void Stop()
            {
            }
        }
    }
}