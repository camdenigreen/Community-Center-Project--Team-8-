﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal interface IDataDelegate
    {
        string ProcedureName { get; }

        void PrepareCommand(Command command);
    }
}
