using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CSVReader
{
    public static List<TData> ReadFile<TData>(string path, char delimeter) where TData : new()
    {
        if (!File.Exists(path)) return null;

        using var streamReader = new StreamReader(path);

        string? line = streamReader.ReadLine();

        if (line is null) return null;

        var data = line.Split(delimeter);
        var propertyInfo = typeof(TData).GetProperties();

        if (data.Length != propertyInfo.Length) return null;

        //TODO: Can add aditional header checking

        var result = new List<TData>();
        while (!streamReader.EndOfStream)
        {
            line = streamReader.ReadLine();

            if (line is null) continue;

            data = line.Split(delimeter);
            TData row = new TData();
            propertyInfo = row.GetType().GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                //TODO: for testing purposes only strings. In later development maybe add other types;
                propertyInfo[i].SetValue(row, data[i], null);
            }

            result.Add(row);
        }

        return result;
    }
}