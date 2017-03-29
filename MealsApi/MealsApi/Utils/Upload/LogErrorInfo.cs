using System;

namespace MealsApi.Utils.Upload
{
    public class LogErrorInfo
    {
        public string ErrorMessage { get; private set; }
        public Exception Exception { get; private set; }
        public bool IsException { get; private set; }

        public LogErrorInfo(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsException = false;
        }

        public LogErrorInfo(Exception exception)
        {
            Exception = exception;
            IsException = true;
        }
    }
}