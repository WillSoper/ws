using System;
using Xunit;
using AdventOfCode2018;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeTests
{
    public class Day5Tests
    {
        [Fact]
        public void exampleOneParsedCorrectly()
        {
            //Arrange
            string exampleInput = "dabAcCaCBAcCcaDA";
            string correctAnswer = "dabCBAcaDA";
            Day5Solution slnUnderTest = new Day5Solution();

            //Act
            string result = slnUnderTest.getPt1AnswerString(exampleInput);
            
            //Assert
            Assert.Equal(correctAnswer, result);
        }

        [Fact]
        public void exampleOneAnswerCorrect()
        {        
            //8829 is too low
            //9203 is too high  -  durrr. I included a \n
            //9202 is right answer

            //Arrange
            string exampleInput = "dabAcCaCBAcCcaDA";
            int correctAnswer = 10;
            Day5Solution slnUnderTest = new Day5Solution();

            //Act
            int result = slnUnderTest.getPt1Answer(exampleInput);
            
            //Assert
            Assert.Equal(correctAnswer, result);
        }

        [Fact]
        public void part2correctAnswer()
        {
            //Arrange   
            string exampleInput = "dabAcCaCBAcCcaDA";
            // string correctAnswer = "daDA";
            int correctAnswer = 4;
            Day5Solution slnUnderTest = new Day5Solution();

            //Act
            int result = slnUnderTest.getPt2Answer(exampleInput);
            
            //Assert
            Assert.Equal(correctAnswer, result);
        }
    }

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
    }

    public class Day12Tests
    {
        [Fact]
        public void potLayoutReturned()
        {
            //Arrange
            Day12Solution slnUnderTest = new Day12Solution();
            string initialState = "#..#.#..##......###...###";
            Dictionary<int, bool> correctLayout = new Dictionary<int, bool>();
            correctLayout.Add(0, true);
            correctLayout.Add(1, false);
            correctLayout.Add(2, false);
            correctLayout.Add(3, true);
            correctLayout.Add(4, false);
            correctLayout.Add(5, true);
            correctLayout.Add(6, false);
            correctLayout.Add(7, false);
            correctLayout.Add(8, true);
            correctLayout.Add(9, true);
            correctLayout.Add(10, false);
            correctLayout.Add(11, false);
            correctLayout.Add(12, false);
            correctLayout.Add(13, false);
            correctLayout.Add(14, false);
            correctLayout.Add(15, false);
            correctLayout.Add(16, true);
            correctLayout.Add(17, true);
            correctLayout.Add(18, true);
            correctLayout.Add(19, false);
            correctLayout.Add(20, false);
            correctLayout.Add(21, false);
            correctLayout.Add(22, true);
            correctLayout.Add(23, true);
            correctLayout.Add(24, true);

            //Act
            Dictionary<int, bool> result = slnUnderTest.parseRow(initialState);

            //Assert
            Assert.Equal(correctLayout, result);
        }

        // [Fact]
        // public void firstPatternMatchWorks()
        // {
        //     //Ar
        //     string initialState =           "#..#.#..##......###...###";
        //     string correctFirstIteration =  "#...#....#.....#..#..#..#";
        //     string firstUsefulPattern =     "...## => #";
        //     string firstUsefulIteration =   "#..#.#..##.....####..####";

        //     //1zz1z1zz11zzzzzz111zzz111
        //     //zzz11 => 1

        //     Day12Solution slnUnderTest = new Day12Solution();
            
        //     //Ac
        //     string result = slnUnderTest.performTransform(initialState, firstUsefulPattern);
            
        //     //As
        //     Assert.Equal(firstUsefulIteration, result);
        // }
    }
}
