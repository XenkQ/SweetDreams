using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;

    [Header("Objectives")]
    private static string _completionMaskPath = Application.dataPath + @"/DataFiles/ObjectivesCompletitionMask.txt";
    private static string _csvFilePath = Application.dataPath + @"/DataFiles/Objectives.csv";
    private const char separator = ';';
    private static List<Objective> _objectives; //TODO: in later development change to read only array;
    private static string _completionMask;
    //For test purposes CSVReader is converting everything into strings;
    private static string currentTaskId;

    private void Awake()
    {
        _objectives = CSVReader.ReadFile<Objective>(_csvFilePath, separator);
        LoadCompletitionMask();
    }

    private void Start()
    {
        currentTaskId = GetCurrentTaskId().ToString();
    }

    private void LoadCompletitionMask()
    {
        if (!File.Exists(_completionMaskPath)) return;

        _completionMask = File.ReadAllText(_completionMaskPath);

        if(_completionMask.Length == 0) _completionMask = new string('0', _objectives.Count);
    }

    private int GetCurrentTaskId()
    {
        for(int i = 1; i < _completionMask.Length; i++)
            if (_completionMask[i] == '0') return i - 1;

        return _completionMask.Length > 0 ? 0 : -1;
    }

    private void RefreshCurrentDisplayedTask()
    {
        throw new NotImplementedException();
    }
}