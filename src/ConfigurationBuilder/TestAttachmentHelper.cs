﻿using System;
using NUnit.Framework;
using System.Linq;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration.Attributes;

namespace ConfigurationBuilder;

public class TestData
{
    [Name("Key")]
    public object Key { get; set; }

    [Name("Value")]
    public string Value { get; set; }
}

public static class TestAttachmentHelper
{
    public static void AddTestDataAttachment(string directoryPath, Dictionary<string, object> testrecords)
    {
        string fileName = $"TESTDATA_{DateTime.Now:HH-mm-ss-fffff}.txt";

        List<TestData> records = new();

        var testdataset = testrecords;

        testdataset.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = GetTestDataValue(testdataset[x.Key]) }));

        AddTestAttachment(directoryPath, fileName, (x) =>
        {
            using (var writer = new StreamWriter(x))
            {
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

                csv.WriteRecords(records);

                writer?.Flush();
            };
        });
    }

    public static void AddTestAttachment(string directoryPath, string fileName, Action<string> action)
    {
        string filePath = Path.Combine(directoryPath, fileName);

        action(filePath);

        TestContext.AddTestAttachment(filePath, fileName);

        TestContext.Progress.WriteLine($"***************{filePath} sucessfully created***************");
    }

    private static string GetTestDataValue(object testdata) => testdata.ToString();
}