using UnityEngine;
using UnityEngine.Events;

public class Doors : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;

    public UnityEvent interactionEvent { get; private set; }

    private void Awake()
    {
        if (interactionEvent == null) interactionEvent = new UnityEvent();
    }

    public void Interact()
    {
        if (_animator.GetBool("IsOpen"))
            _animator.SetBool("IsOpen", false);
        else
            _animator.SetBool("IsOpen", true);

        interactionEvent.Invoke();
    }
}
