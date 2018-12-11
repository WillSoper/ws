using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day4Solution
    {
        public Day4Solution()
        {
        }

        public List<RecordDetail> GetSortedRecordsFromFile(IEnumerable<string> fileInput)
        {
            List<RecordDetail> retVal = new List<RecordDetail>();
            foreach (var fileRow in fileInput)
            {
                retVal.Add(GetRecordFromRow(fileRow));
            }
            retVal.Sort((a,b) => DateTime.Compare(a.DateTimeOfAction, b.DateTimeOfAction));
            return retVal;
        }

        public RecordDetail GetRecordFromRow(string rowToProcess)
        {
            RecordDetail retVal = new RecordDetail();
            
            string RegXDateTimeMatch = @"[\[](.*)[\]]";
            var dTmatches = Regex.Match(rowToProcess, RegXDateTimeMatch);
            retVal.DateTimeOfAction = DateTime.Parse(dTmatches.Groups[1].Value);

            string GuardIdRegexMatch = @"[#](\d+)\s";
            var iDmatches = Regex.Match(rowToProcess, GuardIdRegexMatch);
            if (iDmatches.Success)
            {
                retVal.GuardId = int.Parse(iDmatches.Groups[1].Value);
                retVal.GuardAction = "start";                
            }

            else if (rowToProcess.Contains("falls asleep"))
            {
                retVal.GuardAction = "sleep";
            }

            else if (rowToProcess.Contains("wakes up"))
            {
                retVal.GuardAction = "wake";
            }

            return retVal;
        }
        public GuardDetail GetGuardWhoSleptMost(IEnumerable<string> fileInput)
        {
            var sortedRecords = GetSortedRecordsFromFile(fileInput);

            Dictionary<int, int> GuardsAndAmountsSlept = new Dictionary<int, int>();

            int CurrentGuardId = 0;
            DateTime LastGuardSleep = DateTime.MinValue;
            foreach (var item in sortedRecords)
            {
                if (item.GuardAction == "start")
                {
                    CurrentGuardId = item.GuardId;
                    if(!GuardsAndAmountsSlept.ContainsKey(item.GuardId))
                    {
                        GuardsAndAmountsSlept.Add(item.GuardId, 0);
                    }                    
                }
                else if (item.GuardAction == "sleep")
                {
                    LastGuardSleep = item.DateTimeOfAction;
                }
                else if (item.GuardAction == "wake")
                {
                    TimeSpan amountSlept = item.DateTimeOfAction - LastGuardSleep;
                    GuardsAndAmountsSlept[CurrentGuardId] += (int)amountSlept.TotalMinutes;
                }
            }
            
            var guardSleptMost = GuardsAndAmountsSlept.Where(g => g.Value == GuardsAndAmountsSlept.Values.Max()).SingleOrDefault();
            
            return new GuardDetail() {GuardId =guardSleptMost.Key, NumMinutesSlept = guardSleptMost.Value};
        }

        public struct RecordDetail
        {
            public DateTime DateTimeOfAction;
            public int GuardId;
            public string GuardAction;
        }

        public struct GuardDetail
        {
            public int GuardId;
            public int NumMinutesSlept;
        }
    }
}