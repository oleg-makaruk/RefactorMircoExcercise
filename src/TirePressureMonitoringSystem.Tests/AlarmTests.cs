using NSubstitute;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
    [TestFixture]
    public class AlarmTests
    {
        private ISensor _sensor;
        private Alarm _alarm;

        [SetUp]
        public void Setup()
        {
            _sensor = Substitute.For<ISensor>();
            _alarm = new Alarm(_sensor);
        }

        [Test]
        [Category("SetAlarmOn")]
        public void Check_PressureTooLow_ShouldSetAlarmOn()
        {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(16);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsTrue(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOn")]
        public void Check_PressureTooHigh_ShouldSetAlarmOn()
        {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(22);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsTrue(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOff")]
        public void Check_PressureAtLow_ShouldNotSetAlarm()
        {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(17);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsFalse(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOff")]
        public void Check_PressureNormal_ShouldNotSetAlarm()
        {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(19);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsFalse(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOff")]
        public void Check_PressureAtHigh_ShouldNotSetAlarm()
        {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(21);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsFalse(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOff")]
        public void Check_PressureNormalAfterTooHigh_ShouldNotSetAlarm()
        {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(22);
            _alarm.Check();
            _sensor.PopNextPressurePsiValue().Returns(20);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsFalse(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOn")]
        public void Check_PressureHighAfterNormal_ShouldSetAlarmOn()
        {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(20);
            _alarm.Check();
            _sensor.PopNextPressurePsiValue().Returns(22);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsTrue(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOff")]
        public void AlarmOn_Initially_ShouldBeFalse()
        {
            // Assert
            Assert.IsFalse(_alarm.AlarmOn);
        }
    }
}
