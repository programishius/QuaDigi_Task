namespace QuaDigi_Task
{
    public class Measurement
    {
        private DateTime measurementTime;
        private Double measurementValue;
        private MeasurementType type;

        public Measurement(DateTime measurementTime, double measurementValue, MeasurementType type)
        {
            this.measurementTime = measurementTime;
            this.measurementValue = measurementValue;
            this.type = type;
        }

        public DateTime MeasurementTime
        {
            get { return measurementTime; }
            set { measurementTime = value; }
        }

        public double MeasurementValue
        {
            get { return measurementValue; }
            set { measurementValue = value; }
        }

        public MeasurementType Type
        {
            get { return type; }
            set { type = value; }
        }
    }

    public enum MeasurementType
    {
        TEMP,
        SPO2
    }

}
