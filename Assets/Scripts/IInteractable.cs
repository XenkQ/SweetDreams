using UnityEngine.Events;

public interface IInteractable
{
    public UnityEvent interactionEvent { get; }
    public void Interact();
}