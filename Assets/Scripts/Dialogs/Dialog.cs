using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    public string name;

    [TextArea(10, 10)]
    public string Text;
}
