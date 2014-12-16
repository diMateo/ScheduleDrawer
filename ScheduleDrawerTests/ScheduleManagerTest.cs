using System;
using NUnit.Framework;
using ScheduleDrawer.Schedule;
using ScheduleDrawerTests.TestObjects;

namespace ScheduleDrawerTests
{
    [TestFixture]
    public class ScheduleManagerTest
    {
        [Test]
        public void CreateSchedule_SchouldThrowExceptionWhenPlayersAreNull()
        {
            //given
            var scheduleManager = new ScheduleManager();

            //when then
            Assert.Throws<ArgumentNullException>(() => scheduleManager.CreateSchedule(null));
        }

        [Test]
        public void SaveScheduleToCsv_ShouldThrowExceptionWhenFileNameIsNull()
        {
            //given
            var fileName = string.Empty;
            var schedule = ScheduleObjects.ScheduleTest;
            var scheduleManager = new ScheduleManager();

            //when then
            Assert.Throws<ArgumentNullException>(() => scheduleManager.SaveScheduleToCsv(fileName, schedule));
        }

        [Test]
        public void SaveScheduleToCsv_ShouldThrowExceptionWhenScheduleIsNull()
        {
            //given
            const string fileName = "FileName";
            var scheduleManager = new ScheduleManager();

            //when then
            Assert.Throws<ArgumentNullException>(() => scheduleManager.SaveScheduleToCsv(fileName, null));
        }

        [Test]
        public void ReadScheduleFromCsv_ShouldThrowExceptionWhenFileNameIsNull()
        {
            //given
            var fileName = string.Empty;
            var scheduleManager = new ScheduleManager();

            //when then
            Assert.Throws<ArgumentNullException>(() => scheduleManager.ReadScheduleFromCsv(fileName));
        }
    }
}
