using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _name;

    [SerializeField] private TextMeshProUGUI _description;

    [Header("Objectives")]
    private static string csvFilePath = Application.dataPath + @"/DataFiles/Objectives.csv";

    private static List<Objective> _objectives;

    private void Awake()
    {
        _objectives = CSVReader.ReadFile<Objective>(csvFilePath, ';');
    }

    private void Start()
    {
        Debug.Log(csvFilePath);
    }
}