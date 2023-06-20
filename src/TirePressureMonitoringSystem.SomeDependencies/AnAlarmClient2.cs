using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies {
    public class AnAlarmClient2
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.
        private readonly IAlarm _alarm;

        public AnAlarmClient2(IAlarm alarm)
        {
            _alarm = alarm;
        }
        private void DoSomething()
        {
            _alarm.Check();
            bool isAlarmOn = _alarm.AlarmOn;
        }
    }
}
