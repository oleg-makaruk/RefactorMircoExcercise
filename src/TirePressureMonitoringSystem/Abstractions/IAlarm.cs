namespace TDDMicroExercises.TirePressureMonitoringSystem.Abstractions {
    public interface IAlarm
    {
        void Check();
        bool AlarmOn { get; }
    }
}
