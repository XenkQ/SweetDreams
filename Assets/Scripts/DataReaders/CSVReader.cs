using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CSVReader
{
    public static List<TData> ReadFile<TData>(string path, char delimeter) where TData : class
    {
        if (!File.Exists(path)) return null;

        using var streamReader = new StreamReader(path);

        string? line = streamReader.ReadLine();

        if (line is null) return null;

        var data = line.Split(delimeter);
        var properties = typeof(TData).GetProperties();

        if (data.Length != properties.Length) return null;

        //Can add aditional header checking

        var result = new List<TData>();
        while (!streamReader.EndOfStream)
        {
            line = streamReader.ReadLine();

            if (line is null) continue;

            data = line.Split(delimeter);

            for (int i = 0; i < properties.Length; i++)
            {
                //for testing purposes only strings. In later development maybe add other types;
                properties[i].SetValue(properties[i], data[i]);
            }
        }

        foreach (var s in result) Debug.Log(s);

        return result;
    }
}