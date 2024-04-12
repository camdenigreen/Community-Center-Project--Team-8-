using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string key)
            : base(String.Format("The requested record with key [{0}] does not exist.", key))
        {

        }

        protected RecordNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {

        }
    }
}
