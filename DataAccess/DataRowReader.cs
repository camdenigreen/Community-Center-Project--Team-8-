using DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataRowReader : IDataRowReader
    {
        private readonly SqlDataReader _reader;

        public DataRowReader(SqlDataReader reader)
        {
            _reader = reader;
        }

        public bool GetBoolean(string name)
        {
            return GetValue(name, _reader.GetBoolean);
        }

        public byte GetByte(string name)
        {
            return GetValue(name, _reader.GetByte);
        }

        public DateTime GetDateTime(string name, DateTimeKind kind)
        {
            DateTime dateTime = GetValue(name, _reader.GetDateTime);

            return DateTime.SpecifyKind(dateTime, kind);
        }

        public DateTimeOffset GetDateTimeOffset(string name)
        {
            return GetValue(name, _reader.GetDateTimeOffset);
        }

        public int GetInt32(string name)
        {
            return GetValue(name, _reader.GetInt32);
        }

        public string GetString(string name)
        {
            return GetValue(name, _reader.GetString);
        }

        private int GetOrdinal(string name)
        {
            try
            {
                return _reader.GetOrdinal(name);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ColumnNotFoundException(name, ex);
            }
        }

        public T GetValue<T>(string name)
        {
            return (T)_reader.GetValue(GetOrdinal(name));
        }

        public T GetValue<T>(string name, T ifDbNull)
        {
            int ordinal = GetOrdinal(name);

            return _reader.IsDBNull(ordinal) ? ifDbNull : (T)_reader.GetValue(ordinal);
        }

        private T GetValue<T>(string name, Func<int, T> getter)
        {
            return getter(GetOrdinal(name));
        }

        public bool Read()
        {
            return _reader.Read();
        }
    }
}
