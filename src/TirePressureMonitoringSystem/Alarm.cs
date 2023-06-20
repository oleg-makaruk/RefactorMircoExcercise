using TDDMicroExercises.TirePressureMonitoringSystem.Abstractions;
using TDDMicroExercises.TirePressureMonitoringSystem.Constants;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
    {
        private readonly double _lowPressureThreshold;
        private readonly double _highPressureThreshold;
        private readonly ISensor _sensor;

        // TODO: Refactor clients to use DI and remove default constructor.
        public Alarm()
        {
            _sensor = new Sensor();
            _lowPressureThreshold = TirePressureThresholds.Low;
            _highPressureThreshold = TirePressureThresholds.High;
        }

        public Alarm(ISensor sensor, double lowPressureThreshold, double highPressureThreshold)
        {
            _sensor = sensor;
            _lowPressureThreshold = lowPressureThreshold;
            _highPressureThreshold = highPressureThreshold;
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();
            AlarmOn = !IsPressureNormal(psiPressureValue);
        }

        public bool AlarmOn { get; private set; }

        private bool IsPressureNormal(double pressure)
        {
            return pressure >= _lowPressureThreshold && pressure <= _highPressureThreshold;
        }
    }
}
