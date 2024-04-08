﻿using DataAccess.IDataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataDelegates
{
    public abstract class NonQueryDataDelegate<T> : DataDelegate, INonQueryDataDelegate<T>
    {
        protected NonQueryDataDelegate(string procedureName)
            : base(procedureName)
        {

        }

        public abstract T Translate(Command command);
    }
}
