using System;
using Xunit;
using AdventOfCode2018;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeTests
{
    public class Day4Tests
    {
        [Fact]
        public void DateTimeParsedCorrectly()
        {
            //Arrange
            Day4Solution slnUnderTest = new Day4Solution();
            string testInput = "[1518-11-01 00:00] Guard #10 begins shift";
            DateTime correctDateParsed = new DateTime(year: 1518, month: 11, day: 01);

            //Act
            var result = slnUnderTest.GetRecordFromRow(testInput);

            //Assert
            Assert.Equal(correctDateParsed, result.DateTimeOfAction);
        }

        [Fact]
        public void sortedListOfRecordsReturned()
        {
            //Arrange
            Day4Solution slnUnderTest = new Day4Solution();
            DateTime correctFirstDate = DateTime.Parse("1518-11-03 00:29");
            DateTime correctLastDate = DateTime.Parse("1518-11-04 00:36");

            List<string> testRecords = new List<string>() {                
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-03 00:29] wakes up"
            };

            //Act
            var result = slnUnderTest.GetSortedRecordsFromFile(testRecords);

            //Assert
            Assert.Equal(correctFirstDate, result[0].DateTimeOfAction);
            Assert.Equal(correctLastDate, result[2].DateTimeOfAction);
        }

        //newGuard on shift found
        [Fact]
        public void newGuardOnShiftFound()
        {
            //Arrange 
            Day4Solution slnUnderTest = new Day4Solution();
            int correctGuardId = 99; 
            string correctGuardAction = "start";
            string testInput = "[1518-11-04 00:02] Guard #99 begins shift";
            
            //Act 
            var result = slnUnderTest.GetRecordFromRow(testInput);

            //Assert
            Assert.Equal(correctGuardId, result.GuardId);
            Assert.Equal(correctGuardAction, result.GuardAction);
        }

        [Fact]        
        public void guardFallsAsleepFound()
        {
            //Arrange
            Day4Solution slnUnderTest = new Day4Solution();
            string correctGuardAction = "sleep";
            string testInput = "[1518-04-18 00:06] falls asleep";
            
            //Act
            var result = slnUnderTest.GetRecordFromRow(testInput);

            //Assert
            Assert.Equal(correctGuardAction, result.GuardAction);
        }

        [Fact]
        public void guardWakesUpFound()
        {
            //Arrange
            Day4Solution slnUnderTest = new Day4Solution();
            string correctGuardAction = "wake";
            string testInput = "[1518-02-26 00:51] wakes up";
            
            //Act
            var result = slnUnderTest.GetRecordFromRow(testInput);

            //Assert
            Assert.Equal(correctGuardAction, result.GuardAction);
        }

        [Fact]
        public void totalTimeGuardAsleepFound()
        {
            //Arrange
            Day4Solution slnUnderTest = new Day4Solution();
            var testRecords = File.ReadAllLines("../../../TestInputs/day4test.txt");
            int correctNumMinutesAsleep = 50;

            //Act
            var result = slnUnderTest.GetGuardWhoSleptMost(testRecords);            

            //Assert
            Assert.Equal(correctNumMinutesAsleep, result.NumMinutesSlept);
        }

        [Fact]
        public void mostAsleepMinuteForGivenGuardFound()
        {
            //Arrange
            Day4Solution slnUnderTest = new Day4Solution();
            var testRecords = File.ReadAllLines("../../../TestInputs/day4test.txt");
            int mostAsleepMinute = 24;            

            // //Act
            int GuardId = 10;
            int result = slnUnderTest.GetMinuteGuardMostAsleep(testRecords, GuardId);

            //Assert
            Assert.Equal(mostAsleepMinute, result);
        }

        [Fact] void SolutionDay1()
        {
            //Arrange
            Day4Solution slnUnderTest = new Day4Solution();
            var testRecords = File.ReadAllLines("../../../TestInputs/day4.txt");            

            // //Act                        
            var guard = slnUnderTest.GetGuardWhoSleptMost(testRecords);
            int minuteGuardSleptMost = slnUnderTest.GetMinuteGuardMostAsleep(testRecords, guard.GuardId);

            //Assert
            Assert.Equal(28, minuteGuardSleptMost);
            Assert.Equal(502, guard.NumMinutesSlept);
            Assert.Equal(2753, guard.GuardId);

            //14056 is too low  -  multiplied the wrong numbers!! DUMMY!
            //77084 is correct
        }

        [Fact]
        public void FindAllGuards()
        {
            //Arrange
            Day4Solution slnUnderTest = new Day4Solution();
            List<string> testRecords = new List<string>(){
                "[1518-07-02 23:59] Guard #2251 begins shift",
                "[1518-08-08 00:55] falls asleep",
                "[1518-04-30 23:58] Guard #911 begins shift",
                "[1518-03-06 23:56] Guard #2707 begins shift",
                "[1518-04-06 00:42] falls asleep",
                "[1518-08-06 23:59] Guard #1999 begins shift"

            };
            List<int> correctListOfAllGuards = new List<int>() {911, 1999, 2251, 2707};

            //Act
            var result = slnUnderTest.FindAllGuards(testRecords);
            
            //Assert
            Assert.Equal(correctListOfAllGuards.Count, result.Count);
        }
        
        
        [Fact]
        public void SolutionDay1pt2()
        {
            //Arrange
            Day4Solution slnUnderTest = new Day4Solution();
            var testRecords = File.ReadAllLines("../../../TestInputs/day4.txt");     

            //Act
            var guard = slnUnderTest.GetGuardWhoSleptOnOneMinuteMost(testRecords);
            int minuteGuardSleptMost = slnUnderTest.GetMinuteGuardMostAsleep(testRecords, guard.GuardId);            

            //Assert
            Assert.Equal(1213, guard.GuardId);
            Assert.Equal(19, minuteGuardSleptMost);
            Assert.Equal(23047, guard.GuardId*minuteGuardSleptMost);
        }

// Strategy 2: Of all guards, which guard is most frequently asleep on the same minute?
// In the example above, Guard #99 spent minute 45 asleep more than any other guard or 
//minute - three times in total. (In all other cases, any guard spent any minute asleep 
//at most twice.)

// What is the ID of the guard you chose multiplied by the minute you chose? 
//  (In the above example, the answer would be 99 * 45 = 4455.)
    }
}
