﻿using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData.Models;
using DataAccess;
using DataAccess.Exceptions;

namespace DatabaseData.DataDelegates
{
    internal class RetrieveBalanceDataDelegate : DataReaderDelegate<decimal>
    {
        private readonly int _personID;

        public RetrieveBalanceDataDelegate(int personID)
            : base("People.RetrieveBalance")
        {
            _personID = personID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
        }

        public override decimal Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException(_personID.ToString());
            }

            return reader.GetValue<decimal>("Balance", 0.00m);
        }
    }
}