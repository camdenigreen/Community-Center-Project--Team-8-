﻿using DataAccess.IDataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataDelegates
{
    public abstract class DataReaderDelegate<T> : DataDelegate, IDataReaderDelegate<T>
    {
        protected DataReaderDelegate(string procedureName)
            : base(procedureName)
        {

        }

        public abstract T Translate(Command command, IDataRowReader reader);
    }
}
