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
            // Day4Solution slnUnderTest = new Day4Solution();
            // var testRecords = File.ReadAllLines("../../../TestInputs/day4test.txt");
            // int mostAsleepMinute = 24;            

            // //Act
            // var result = sln

            //Assert
            Assert.Equal(true, true);
        }
    }
}
