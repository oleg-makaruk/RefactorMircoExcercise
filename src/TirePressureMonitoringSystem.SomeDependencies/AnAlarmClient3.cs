using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies {
    public class AnAlarmClient3
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.
        private readonly IAlarm _alarm;

        public AnAlarmClient3(IAlarm alarm)
        {
            _alarm = alarm;
        }

        public void DoSomething() 
        {
            _alarm.Check();
        }

		public void DoSomethingElse()
		{
			bool isAlarmOn = _alarm.AlarmOn;
		}
    }
}
