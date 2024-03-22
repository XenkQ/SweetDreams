using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    public DialogWriters Writer;

    [TextArea(10, 10)]
    public string Text;
}
