using QuaDigi_Task;

List<Measurement> measurements = new List<Measurement>();
measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:04:45"), 35.79, MeasurementType.TEMP));
measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:01:18"), 98.78, MeasurementType.SPO2));
measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:09:07"), 35.01, MeasurementType.TEMP));
measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:03:34"), 96.49, MeasurementType.SPO2));
measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:02:01"), 35.82, MeasurementType.TEMP));
measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:05:00"), 97.17, MeasurementType.SPO2));
measurements.Add(new Measurement(DateTime.Parse("2017-01-03T10:05:01"), 95.08, MeasurementType.SPO2));

DateTime startDate = DateTime.Parse("2017-01-03T09:56:45");

MeasurmentSampling measurmentSampling = new MeasurmentSampling();
var sampled = measurmentSampling.Sample(startDate, measurements);
foreach (var mes in sampled)
{
   foreach (var measurement in mes.Value)
    {
        Console.WriteLine($"{measurement.MeasurementTime.ToString()}, {measurement.Type}, {measurement.MeasurementValue}");
    }
}
