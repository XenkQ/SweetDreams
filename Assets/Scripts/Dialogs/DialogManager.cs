using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DialogManager : MonoBehaviour
{
    [SerializeField] private float _delayBeforeNextText;
    [SerializeField] private float _writingSpeed;
    public bool IsWritingDialog;
    private Queue<IDialogsOwner> _dialogsQueue = new Queue<IDialogsOwner>();
    private TextMeshProUGUI _textMeshProUGUI;
    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _textMeshProUGUI.text = "";

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
        IsWritingDialog = true;

        while (Instance._dialogsQueue.Count > 0)
        {
            foreach(var dialog in dialogContainer.Dialogs)
            {
                foreach (char letter in dialog.Text)
                {
                    _textMeshProUGUI.text += letter;
                    yield return new WaitForSeconds(_writingSpeed);
                }

                yield return new WaitForSeconds(_delayBeforeNextText);

                _textMeshProUGUI.text = "";
            }

            Instance._dialogsQueue.Dequeue();
        }

        IsWritingDialog = false;
    }
}
