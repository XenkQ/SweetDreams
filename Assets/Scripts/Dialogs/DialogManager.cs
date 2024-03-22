using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DialogManager : MonoBehaviour
{
    [SerializeField] private float _delayBeforeNextText;
    [SerializeField] private float _writingSpeed;
    public bool IsWritingDialog;
    private Queue<IDialogsOwner> _dialogsQueue = new Queue<IDialogsOwner>();

    private TextMeshProUGUI _dialogDisplay;
    private const string COLOR_END_TAG = "</color>";

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        _dialogDisplay = GetComponent<TextMeshProUGUI>();
        _dialogDisplay.text = "";

        if (Instance is null) Instance = this;
    }

    public static void StartWritingDialog(IDialogsOwner dialogContainer)
    {
        Instance._dialogsQueue.Enqueue(dialogContainer);

        if (Instance.IsWritingDialog) return;

        Instance.StartCoroutine(Instance.WriteDialog(dialogContainer));
    }

    private IEnumerator WriteDialog(IDialogsOwner dialogContainer)
    {
        //TODO: Create algorithm that creates char array with size prefix.Length + dialog.Text.Length + postfix.Length
        //that is adding text after prefix and before postfix

        IsWritingDialog = true;

        while (Instance._dialogsQueue.Count > 0)
        {
            foreach(var dialog in dialogContainer.Dialogs)
            {
                foreach (char letter in dialog.Text)
                {
                    string prefix = $"<{DialogHexColors.GetHexColorRelatedToDialogWriters(dialog.Writer)}>";
                    StringBuilder sb = new StringBuilder(prefix.Length + dialog.Text.Length + COLOR_END_TAG.Length);
                    sb.Append(prefix).Append(letter).Append(COLOR_END_TAG);
                    _dialogDisplay.text += sb.ToString();
                    yield return new WaitForSeconds(_writingSpeed);
                }

                yield return new WaitForSeconds(_delayBeforeNextText);

                _dialogDisplay.text = "";
            }

            Instance._dialogsQueue.Dequeue();
        }

        IsWritingDialog = false;
    }
}
