using System;
using System.Collections.Generic;
using System.Linq;

namespace MealsApi.Utils.Upload
{
    public class FormDataConverterLogger : IFormDataConverterLogger
    {
        private Dictionary<string, List<LogErrorInfo>> Errors { get; set; }

        public FormDataConverterLogger()
        {
            Errors = new Dictionary<string, List<LogErrorInfo>>();
        }

        public void LogError(string errorPath, Exception exception)
        {
            AddError(errorPath, new LogErrorInfo(exception));
        }

        public void LogError(string errorPath, string errorMessage)
        {
            AddError(errorPath, new LogErrorInfo(errorMessage));
        }

        public List<LogItem> GetErrors()
        {
            return Errors.Select(m => new LogItem()
            {
                ErrorPath = m.Key,
                Errors = m.Value.Select(t => t).ToList()
            }).ToList();
        }

        public void EnsureNoErrors()
        {
            if (Errors.Any())
            {
                var errors = Errors
                    .SelectMany(m => m.Value)
                    .Select(m => (m.ErrorMessage ?? (m.Exception != null ? m.Exception.Message : "")))
                    .ToList();

                string errorMessage = String.Join(" ", errors);

                throw new Exception(errorMessage);
            }
        }

        private void AddError(string errorPath, LogErrorInfo info)
        {
            List<LogErrorInfo> listErrors;
            if (!Errors.TryGetValue(errorPath, out listErrors))
            {
                listErrors = new List<LogErrorInfo>();
                Errors.Add(errorPath, listErrors);
            }
            listErrors.Add(info);
        }

        
    }
}