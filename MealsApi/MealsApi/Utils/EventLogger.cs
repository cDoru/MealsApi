using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MealsApi.Utils
{
    public static class EventLogger
    {
        private const string StackTraceFormatting = "File {0} line {1} column {2}";
        const string EventLogName = "MealsApiEventLog";

        private static void TryInitializeSource(string source = EventLogName)
        {
            if (!EventLog.SourceExists(source))
            {
                var eventSourceData = new EventSourceCreationData(source, source);
                EventLog.CreateEventSource(eventSourceData);
            }
        }

        public static void WriteError(Exception exception, string additionalInfo, string source = EventLogName)
        {
            try
            {
                TryInitializeSource(source);
                string message = string.Empty;
                var exceptionMessage = GetAllMessages(exception);

                if (!string.IsNullOrEmpty(additionalInfo))
                {
                    message += string.Format("Error Happened. Additional info {0} Exception: {1}", additionalInfo,
                        Environment.NewLine);
                }

                message += exceptionMessage;

                using (var tastierLogger = new EventLog(source, ".", source))
                {
                    tastierLogger.WriteEntry(message, EventLogEntryType.Error);
                }
            }
            catch
            {

            }
        }

        public static void WriteInfo(string information, string source = EventLogName)
        {
            try
            {
                TryInitializeSource(source);
                using (var tastierLogger = new EventLog(source, ".", source))
                {
                    tastierLogger.WriteEntry(string.Format("Information: {0}", information), EventLogEntryType.Information);
                }
            }
            catch
            {

            }
        }

        private static IEnumerable<TSource> FromHierarchy<TSource>(TSource source, Func<TSource, TSource> nextItem, Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        private static IEnumerable<TSource> FromHierarchy<TSource>(TSource source, Func<TSource, TSource> nextItem) where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

        private static string GetAllMessages(Exception exception)
        {
            var messages = FromHierarchy(exception, ex => ex.InnerException)
                .Select(ex =>
                {
                    var exceptionName = ex.GetType().Name;
                    var stackTrace = ex.StackTrace;
                    var st = new StackTrace(ex, true);
                    var frames = st.GetFrames();

                    var builder = new StringBuilder();
                    builder.AppendLine(string.Format("===================== Exception body for {0} ===================== ", exceptionName));

                    // append exception message
                    builder.AppendLine("Message");
                    builder.AppendLine(ex.Message);
                    builder.AppendLine("End of message");

                    // append stacktrace
                    builder.AppendLine("Original stack trace");
                    builder.AppendLine(stackTrace);
                    builder.AppendLine("End of original stack trace");

                    if (frames != null)
                    {
                        builder.AppendLine("Original stack trace (with line number)");
                        // process stacktrace
                        foreach (var frame in frames)
                        {
                            var frameLineNumber = frame.GetFileLineNumber();
                            var frameColumnNumber = frame.GetFileColumnNumber();

                            if (frameLineNumber != 0 || frameColumnNumber != 0)
                            {
                                builder.AppendLine(string.Format(StackTraceFormatting, frame.GetFileName(), frameLineNumber, frameColumnNumber));
                            }
                        }

                        builder.AppendLine("End of original stack trace (with line number)");
                    }

                    builder.AppendLine(string.Format("===================== End Exception body for {0} ===================== ", exceptionName));
                    return builder.ToString();
                });

            return String.Join(Environment.NewLine, messages);
        }
    }
}