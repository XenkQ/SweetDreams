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

    public static ObjectivesManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance is null) Instance = this;

        _objectives = CSVReader.ReadFile<Objective>(_csvFilePath, separator);
        LoadCompletitionMask();
    }

    private void Start()
    {
        int currentId = GetCurrentTaskId();
        currentTaskId = currentId.ToString();
        _objectivesUI.Refresh(_objectives[currentId]);
    }

    private void LoadCompletitionMask()
    {
        if (!File.Exists(_completionMaskPath)) return;

        _completionMask = File.ReadAllText(_completionMaskPath).ToCharArray();

        if (_completionMask.Length == 0) _completionMask = new char[_objectives.Count];
    }

    public static void EndObjective(int id, bool isCompleted)
    {
        if (id < 0) return;
        if (IsObjectiveCompleted(id)) return;

        _completionMask[id] = '1';

        SaveObjectivesCompletition();
        LoadNextTask();
    }

    public static bool IsObjectiveCompleted(int id)
    {
        if (id < 0) return false;

        if (_completionMask[id] == '1') return true;
        return false;
    }

    private static void SaveObjectivesCompletition()
    {
        if (!File.Exists(_completionMaskPath)) return;

        File.WriteAllText(_completionMaskPath, _completionMask.ToString());
    }

    private static void LoadNextTask()
    {
        int nextId = GetNextTaskId();
        currentTaskId = nextId.ToString();
        Instance._objectivesUI.Refresh(_objectives[nextId]);
    }

    private static int GetCurrentTaskId()
    {
        if (currentTaskId is not null)
        {
            int id;
            if (int.TryParse(currentTaskId, out id))
                return id;
        }

        for (int i = 1; i < _completionMask.Length; i++)
            if (_completionMask[i] == '0') return i - 1;

        return _completionMask.Length > 0 ? 0 : -1;
    }

    private static int GetNextTaskId()
    {
        int currentId = GetCurrentTaskId();
        if (currentId + 1 < _completionMask.Length)
            return currentId + 1;
        else return -1;
    }
}