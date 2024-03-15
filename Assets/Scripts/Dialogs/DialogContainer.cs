using UnityEngine;

public class DialogContainer : MonoBehaviour, IDialogsOwner
{
    [SerializeField] private string _dialogName;
    [SerializeField] private Dialog[] _dialogs;
    private bool wasDisplayed;

    public Dialog[] Dialogs => _dialogs;

    private void Start()
    {
        TriggerDialog();
    }

    public void TriggerDialog()
    {
        if (wasDisplayed) return;

        DialogManager.StartWritingDialog(this);
        wasDisplayed = true;
    }
}
