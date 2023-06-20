using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies {
    public class AnAlarmClient1
    {
		// A class with the only goal of simulating a dependency on Alert
		// that has impact on the refactoring.
        private readonly IAlarm _alarm;

        public AnAlarmClient1(IAlarm alarm)
        {
            _alarm = alarm;
        }
		
        public AnAlarmClient1()
        {
            _alarm.Check();
            bool isAlarmOn = _alarm.AlarmOn;
        }
    }
}
