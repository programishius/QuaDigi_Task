namespace QuaDigi_Task
{
    public class MeasurmentSampling
    {
        public Dictionary<MeasurementType, List<Measurement>> Sample(DateTime startOfSampling, List<Measurement> unsampledMeasurements)
        {
            Dictionary<MeasurementType, List<Measurement>> result = new Dictionary<MeasurementType, List<Measurement>>();
            foreach (MeasurementType measurementType in unsampledMeasurements.Select(m => m.Type).Distinct())
            {
                DateTime lastTime = new DateTime();
                DateTime currentTime = GetStartDateIn5MinuteInterval(startOfSampling);
                DateTime maxDate = unsampledMeasurements.Where(m => m.Type == measurementType).MaxBy(m => m.MeasurementTime)?.MeasurementTime ?? currentTime;
                List<Measurement> typeMeasurment = unsampledMeasurements.Where(m => m.Type == measurementType).OrderBy(m => m.MeasurementTime).ToList();
                List<Measurement> typeMeasurmentList = new List<Measurement>();
                while (currentTime <= maxDate.AddMinutes(5))
                {
                    Measurement selectedMeasurment = typeMeasurment.LastOrDefault(m => m.MeasurementTime <= currentTime && m.MeasurementTime > lastTime);
                    typeMeasurmentList.Add(new Measurement(currentTime, selectedMeasurment?.MeasurementValue ?? 0, measurementType));
                    lastTime = currentTime;
                    currentTime = currentTime.AddMinutes(5);
                }
                if (typeMeasurmentList.Count > 0)
                    result.Add(measurementType, typeMeasurmentList);

            }
            return result;
        }

        private DateTime GetStartDateIn5MinuteInterval(DateTime time)
        {
            int minutesToSubtract = time.Minute % 5;
            DateTime roundedTime = time.AddMinutes(-minutesToSubtract).AddSeconds(-time.Second).AddMilliseconds(-time.Millisecond);
            return roundedTime.AddMinutes(5);
        }
    }
}
