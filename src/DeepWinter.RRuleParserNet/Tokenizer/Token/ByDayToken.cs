using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
    public class ByDayToken : RRuleToken<ByDayToken.DayList>
    {
        public const string NAME = "BYDAY";

        public ByDayToken(DayList dayList) : base(dayList)
        {
        }

        public override string GetName()
        {
            return NAME;
        }


        // Needed since .net5.0 changed GetShortestDayName to retrieve it from System and so this method returns just M instead of MO on newest Ubuntu
        private static readonly Dictionary<DayOfWeek, string> DayOfWeekShortNames = new Dictionary<DayOfWeek, string>()
        {
            [DayOfWeek.Monday] = "MO",
            [DayOfWeek.Tuesday] = "TU",
            [DayOfWeek.Wednesday] = "WE",
            [DayOfWeek.Thursday] = "TH",
            [DayOfWeek.Friday] = "FR",
            [DayOfWeek.Saturday] = "SA",
            [DayOfWeek.Sunday] = "SU"
        };

        /// <summary>
        /// Helper method to get the required string of the day.
        /// </summary>
        /// <param name="dayOfWeek">DayOfWeek to convert.</param>
        /// <returns>String representative of the DayOfWeek.</returns>
        public static string GetByDayOfWeek(DayOfWeek dayOfWeek)
        {
            return DayOfWeekShortNames[dayOfWeek];
        }

        /// <summary>
        /// Helper method to get the required string which contains multiple days.
        /// </summary>
        /// <param name="dayOfWeeks">DayOfWeek list to convert.</param>
        /// <returns>String representative list of days.</returns>
        public static string GetByDayOfWeek(IEnumerable<DayOfWeek> dayOfWeeks)
        {
            return string.Join(",", dayOfWeeks.Select(GetByDayOfWeek));
        }

        public class DayList
        {
            private readonly List<DayOfWeek> _dayList;

            public DayList(List<DayOfWeek> dayList)
            {
                _dayList = dayList;
            }

            public IReadOnlyList<DayOfWeek> GetDayList()
            {
                return _dayList.AsReadOnly();
            }

            public override bool Equals(object obj)
            {
                if (!(obj is DayList list))
                    return false;

                return list.GetDayList().All(item => _dayList.Contains(item))
                       && _dayList.All(item => ((DayList)obj).GetDayList().Contains(item))
                       && _dayList.Count == list.GetDayList().Count;
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            /// <summary>
            /// Helper method to get the required string of the day.
            /// </summary>
            /// <returns>String representative of the DayOfWeek.</returns>
            public override string ToString()
            {
                return GetByDayOfWeek(_dayList);
            }
        }
    }
}