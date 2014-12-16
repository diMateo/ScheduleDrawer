using System.Linq;
using NUnit.Framework;
using ScheduleDrawer.Schedule;
using ScheduleDrawerTests.TestObjects;

namespace ScheduleDrawerTests
{
    [TestFixture]
    public class ScheduleConverterTest
    {
        [Test]
        public void ConvertScheduleToString_ShouldReturnValidString()
        {
            //given
            var schedule = ScheduleObjects.ScheduleTest;
            var scheduleConverter = new ScheduleConverter();

            //when
            var parsedSchedule = scheduleConverter.ConvertScheduleToString(schedule);

            //then
            Assert.That(parsedSchedule, Is.EqualTo("Round;Home;Away;Home Goals;Away Goals\r\n1;Player_01;Player_02;1;0\r\n1;Player_03;Player_04;2;2\r\n2;Player_02;Player_03;;\r\n2;Player_04;Player_01;;\r\n"));
        }

        [Test]
        public void ConvertStringToSchedule_ShouldReturnValidSchedule()
        {
            //given
            var fileContent = "Round;Home;Away;Home Goals;Away Goals\r\n1;Player_01;Player_02;1;0\r\n1;Player_03;Player_04;2;2\r\n2;Player_02;Player_03;;\r\n2;Player_04;Player_01;;\r\n";
            var expectedSchedule = ScheduleObjects.ScheduleTest.ToList();
            var scheduleConverter = new ScheduleConverter();

            //when
            var result = scheduleConverter.ConvertStringToSchedule(fileContent).ToList();

            //then
            Assert.That(result.Count, Is.EqualTo(expectedSchedule.Count));
            Assert.That(result.First().Home, Is.EqualTo(expectedSchedule.First().Home));
            Assert.That(result.First().Away, Is.EqualTo(expectedSchedule.First().Away));
            Assert.That(result.First().Result, Is.EqualTo(expectedSchedule.First().Result));
            Assert.That(result.First().Round, Is.EqualTo(expectedSchedule.First().Round));
            Assert.That(result[1].Home, Is.EqualTo(expectedSchedule[1].Home));
            Assert.That(result[1].Away, Is.EqualTo(expectedSchedule[1].Away));
            Assert.That(result[1].Result, Is.EqualTo(expectedSchedule[1].Result));
            Assert.That(result[1].Round, Is.EqualTo(expectedSchedule[1].Round));
            Assert.That(result[2].Home, Is.EqualTo(expectedSchedule[2].Home));
            Assert.That(result[2].Away, Is.EqualTo(expectedSchedule[2].Away));
            Assert.That(result[2].Result, Is.EqualTo(expectedSchedule[2].Result));
            Assert.That(result[2].Round, Is.EqualTo(expectedSchedule[2].Round));
            Assert.That(result.Last().Home, Is.EqualTo(expectedSchedule.Last().Home));
            Assert.That(result.Last().Away, Is.EqualTo(expectedSchedule.Last().Away));
            Assert.That(result.Last().Result, Is.EqualTo(expectedSchedule.Last().Result));
            Assert.That(result.Last().Round, Is.EqualTo(expectedSchedule.Last().Round));
        }
    }
}
