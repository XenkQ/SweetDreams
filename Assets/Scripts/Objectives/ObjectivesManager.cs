using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    private static string _completionMaskPath = Application.dataPath + @"/DataFiles/ObjectivesCompletitionMask.txt";
    private static string _csvFilePath = Application.dataPath + @"/DataFiles/Objectives.csv";
    private const char separator = ';';

    //For test purposes CSVReader is converting everything into strings;
    private static List<Objective> _objectives; //TODO: in later development change to read only array;
    private static char[] _completionMask;
    private static string currentTaskId; //TODO: Change into int

    [SerializeField] private ObjectivesUI _objectivesUI;

    private void Awake()
    {
        _objectives = CSVReader.ReadFile<Objective>(_csvFilePath, separator);
        LoadCompletitionMask();
    }

    private void Start()
    {
        currentTaskId = GetCurrentTaskId().ToString();

        _objectivesUI.Refresh(_objectives[GetCurrentTaskId()]);
    }

    public static void EndCurrentTask(bool isCompleted)
    {
        if (isCompleted)
            _completionMask[GetCurrentTaskId()] = '1';
        else 
            _completionMask[GetCurrentTaskId()] = '0';

        SaveObjectivesCompletition();
    }

    public static void SaveObjectivesCompletition()
    {
        if (!File.Exists(_completionMaskPath)) return;

        File.WriteAllText(_completionMaskPath, _completionMask.ToString());
    }

    private void LoadCompletitionMask()
    {
        if (!File.Exists(_completionMaskPath)) return;

        _completionMask = File.ReadAllText(_completionMaskPath).ToCharArray();

        if (_completionMask.Length == 0) _completionMask = new char[_objectives.Count];
    }

    private static int GetCurrentTaskId()
    {
        if(currentTaskId is not null)
        {
            int id;
            if (int.TryParse(currentTaskId, out id))
                return id;
        }

        for (int i = 1; i < _completionMask.Length; i++)
            if (_completionMask[i] == '0') return i - 1;

        return _completionMask.Length > 0 ? 0 : -1;
    }
}