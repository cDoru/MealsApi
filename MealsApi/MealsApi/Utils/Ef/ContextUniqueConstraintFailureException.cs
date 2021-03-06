using System;
using System.Runtime.Serialization;

namespace MealsApi.Utils.Ef
{
    [Serializable]
    public class ContextUniqueConstraintFailureException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ContextUniqueConstraintFailureException()
        {
        }

        public ContextUniqueConstraintFailureException(string message)
            : base(message)
        {
        }

        public ContextUniqueConstraintFailureException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ContextUniqueConstraintFailureException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}