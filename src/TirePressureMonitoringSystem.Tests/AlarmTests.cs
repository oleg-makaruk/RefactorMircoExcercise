using NSubstitute;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests {
    [TestFixture]
    public class AlarmTests {
        private readonly ISensor _sensor;
        private readonly Alarm _alarm;

        public AlarmTests() {
            _sensor = Substitute.For<ISensor>();
            _alarm = new Alarm(_sensor);
        }

        [Test]
        [Category("SetAlarmOn")]
        public void Check_PressureTooLow_ShouldSetAlarmOn() {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(16);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsTrue(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOn")]
        public void Check_PressureTooHigh_ShouldSetAlarmOn() {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(22);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsTrue(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOff")]
        public void Check_PressureAtLow_ShouldNotSetAlarmOn() {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(17);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsFalse(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOff")]
        public void Check_PressureNormal_ShouldNotSetAlarmOn() {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(19);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsFalse(_alarm.AlarmOn);
        }

        [Test]
        [Category("SetAlarmOff")]
        public void Check_PressureAtHigh_ShouldNotSetAlarmOn() {
            // Arrange
            _sensor.PopNextPressurePsiValue().Returns(21);

            // Act
            _alarm.Check();

            // Assert
            Assert.IsFalse(_alarm.AlarmOn);
        }
    }
}
