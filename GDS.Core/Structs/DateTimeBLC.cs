using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GDS.Core.Structs
{
    public struct DateTimeBLC : IComparable, IFormattable, IConvertible, ISerializable, IComparable<DateTimeBLC>, IEquatable<DateTimeBLC>
    {
        // Number of 100ns ticks per time unit
        private const long TicksPerMillisecond = 10000;
        private const long TicksPerSecond = TicksPerMillisecond * 1000;
        private const long TicksPerMinute = TicksPerSecond * 60;
        private const long TicksPerHour = TicksPerMinute * 60;
        private const long TicksPerDay = TicksPerHour * 24;

        // Number of milliseconds per time unit
        private const int MillisPerSecond = 1000;
        private const int MillisPerMinute = MillisPerSecond * 60;
        private const int MillisPerHour = MillisPerMinute * 60;
        private const int MillisPerDay = MillisPerHour * 24;

        private const int DaysPerYear = 360;
        private const int DaysTo10000 = DaysPerYear * 10000;  

        internal const long MinTicks = 0;
        internal const long MaxTicks = DaysTo10000 * TicksPerDay - 1;
        private const long MaxMillis = (long)DaysTo10000 * MillisPerDay;

        
        private const int DatePartYear = 0;
        private const int DatePartDayOfYear = 1;
        private const int DatePartMonth = 2;
        private const int DatePartDay = 3;

        private const int HoursPerDay = 24;

        
        private static readonly int[] DaysToMonth360 = {
            0, 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, 360};
        private ulong dateData;

        // Constructs a DateTime from a given year, month, and day. The
        // time-of-day of the resulting DateTime is always midnight.
        //
        public DateTimeBLC(int year, int month, int day)
        {
            this.dateData = (UInt64)DateToHours(year, month, day);
        }

        private static long DateToHours(int year, int month, int day)
        {
            var days = 0;
            if(year >= 1)
            {
                days += (year - 1) * DaysPerYear;
            }
            if (month >= 1 && month <= 12)
            {
                int[] dtm = DaysToMonth360;
                days += dtm[month-1];
            }
            if (day >= 1 && day <= 30)
            {
                days += day - 1;
            }
            return days * HoursPerDay;

        }


        // Constructs a DateTime from a given year, month, day, hour,
        // minute, and second.
        //
        public DateTimeBLC(int year, int month, int day, int hour)
        {
           
            this.dateData = (UInt64)(DateToHours(year, month, day) + hour);
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(DateTimeBLC other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(DateTimeBLC other)
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
