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

        public void GetSolutionPart1(string[] fileInput)
        {
            var GuardSleptMost = GetGuardWhoSleptMost(fileInput);
            Console.WriteLine("Guard {0} slept for {1} mins");
            Console.WriteLine("Most common minute {0}", GetMinuteGuardMostAsleep(fileInput, GuardSleptMost.GuardId));
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

        public int GetMinuteGuardMostAsleep(IEnumerable<string> fileInput, int guardId)
        {
            var minutesAndCounts = getMinutesAndCountsForGivenGuard(fileInput, guardId);

            return minutesAndCounts.Where(g => g.Value == minutesAndCounts.Values.Max()).SingleOrDefault().Key;
        }

        private Dictionary<int, int> getMinutesAndCountsForGivenGuard(IEnumerable<string> fileInput, int guardId)
        {
            Dictionary<int, int> minutesAndCounts = new Dictionary<int, int>();
            for (int i = 0; i < 60; i++)
            {
                minutesAndCounts.Add(i, 0);
            }

            var sortedRecords = GetSortedRecordsFromFile(fileInput);

            int CurrentGuardId = 0;            
            DateTime LastGuardSleep = DateTime.MinValue;
            foreach (var item in sortedRecords)
            {
                if (item.GuardAction == "start")
                {
                    CurrentGuardId = item.GuardId;
                }  
                if (CurrentGuardId == guardId)
                {
                    if (item.GuardAction == "sleep")
                    {
                        LastGuardSleep = item.DateTimeOfAction;
                    } 
                    else if (item.GuardAction == "wake")
                    {
                        TimeSpan amountSlept = item.DateTimeOfAction - LastGuardSleep;
                        for (int i = 0; i < amountSlept.TotalMinutes; i++)
                        {
                            int thisMinute = LastGuardSleep.Minute + i;
                            if (thisMinute > 60)
                            {
                                thisMinute = thisMinute -60;
                            }
                            minutesAndCounts[thisMinute]++;
                        }
                    }
                }                            
            }
            return minutesAndCounts;
        }

        public GuardDetail GetGuardWhoSleptOnOneMinuteMost(IEnumerable<string> fileInput)
        {
            int GuardAsleepMost = 0;
            int MinuteGuardAsleepMost = 0;
            int AmountGuardAsleepMost = 0;
            
            var AllGuards = FindAllGuards(fileInput);
            foreach (var guard in AllGuards)
            {
                var minutesAndCounts = getMinutesAndCountsForGivenGuard(fileInput, guard);
                var thisGuardDetail = minutesAndCounts.Where(g => g.Value == minutesAndCounts.Values.Max()).FirstOrDefault();
                if (thisGuardDetail.Value > AmountGuardAsleepMost)
                {
                    GuardAsleepMost = guard;
                    MinuteGuardAsleepMost = thisGuardDetail.Key;
                    AmountGuardAsleepMost = thisGuardDetail.Value;
                }
            }
            return new GuardDetail() { GuardId = GuardAsleepMost};
        }

        public List<int> FindAllGuards(IEnumerable<string> fileInput)
        {
            List<int> retVal = new List<int>();
            var sortedRecords = GetSortedRecordsFromFile(fileInput);
            foreach (var record in sortedRecords)
            {
                if (record.GuardAction == "start" && !retVal.Contains(record.GuardId))
                {
                    retVal.Add(record.GuardId);
                }
            }
            return retVal;
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
};