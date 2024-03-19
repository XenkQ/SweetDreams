using System;
using UnityEngine;

public class MyConverter
{
    //for current purposes not needed
    public static object ConvertFromTo<TFrom, TTo>(TFrom from)
    {
        if(typeof(TFrom).Equals(typeof(string)) && typeof(TTo).Equals(typeof(int)))
        {
            Debug.Log("Parsing...");
            return Convert.ChangeType(Convert.ToInt32(from), typeof(TTo));
        }

        return default(TTo);
    }
}