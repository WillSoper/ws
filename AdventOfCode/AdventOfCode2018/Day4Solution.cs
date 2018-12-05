using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class Day4Solution
    {
        public Day4Solution()
        {
        }

        public RecordDetail GetRecordFromRow(string rowToProcess)
        {
            RecordDetail retVal = new RecordDetail();
            string RegXDateTimeMatch = @"[\[](.*)[\]]";
            var matches = Regex.Match(rowToProcess, RegXDateTimeMatch);
            retVal.DateTimeOfAction = DateTime.Parse(matches.Groups[1].Value);
            return retVal;
        }

        public struct RecordDetail
        {
            public DateTime DateTimeOfAction;
        }
    }
}