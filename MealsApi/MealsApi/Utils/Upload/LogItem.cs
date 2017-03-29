using System.Collections.Generic;

namespace MealsApi.Utils.Upload
{
    public class LogItem
    {
        public string ErrorPath { get; set; }
        public List<LogErrorInfo> Errors { get; set; }
    }
}