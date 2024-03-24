using UnityEngine;
using UnityEngine.Events;

public class Bed : MonoBehaviour, IInteractable
{
    public UnityEvent interactionEvent { get; private set; }

    private void Awake()
    {
        if(interactionEvent == null) interactionEvent = new UnityEvent();
    }

    public void Interact()
    {
        interactionEvent.Invoke();
    }
}
