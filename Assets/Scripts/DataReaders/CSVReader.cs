using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CSVReader
{
    public static List<DataType> ReadFile<DataType>(string path, char delimeter) where DataType : class
    {
        using var streamReader = new StreamReader(path);
        string? line = streamReader.ReadLine();

        if (line is null) return null;

        var data = line.Split(delimeter);
        var properties = typeof(DataType).GetProperties();

        if (data.Length != properties.Length) return null;

        //Can add aditional header checking

        var result = new List<DataType>();
        while (!streamReader.EndOfStream)
        {
            line = streamReader.ReadLine();

            if (line is null) continue;

            data = line.Split(delimeter);

            for (int i = 0; i < properties.Length; i++)
                properties[i].SetValue(properties[i], data[i]);
        }

        foreach (var s in result) Debug.Log(s);

        return result;
    }
}