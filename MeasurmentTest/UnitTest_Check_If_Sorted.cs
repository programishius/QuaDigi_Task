using QuaDigi_Task;

namespace MeasurmentTest
{
    public class UnitTest_Check_If_Sorted
    {
        [Fact]
        public void MeasurementList_ShouldBeSortedByTime()
        {
            List<Measurement> measurements = new List<Measurement>();
            measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:04:45"), 35.79, MeasurementType.TEMP));
            measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:01:18"), 98.78, MeasurementType.SPO2));
            measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:09:07"), 35.01, MeasurementType.TEMP));
            measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:03:34"), 96.49, MeasurementType.SPO2));
            measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:02:01"), 35.82, MeasurementType.TEMP));
            measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:05:00"), 97.17, MeasurementType.SPO2));
            measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:05:01"), 95.08, MeasurementType.SPO2));


            DateTime initDate = DateTime.Parse("2017-01-03T09:54:45");
            MeasurmentSampling ms = new MeasurmentSampling();

            foreach (var mes in ms.Sample(initDate, measurements))
            {
                Assert.True(IsSorted(mes.Value), $"The measurement list of {mes.Key} is not sorted by time.");
            }
        }

        private bool IsSorted(List<Measurement> measurements)
        {
            for (int i = 1; i < measurements.Count; i++)
            {
                if (measurements[i].MeasurementTime < measurements[i - 1].MeasurementTime)
                {
                    return false;
                }
            }
            return true;
        }
    }
}