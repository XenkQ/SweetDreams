using UnityEngine;

public class Doors : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;

    public void Interact()
    {
        if (_animator.GetBool("IsOpen"))
            _animator.SetBool("IsOpen", false);
        else
            _animator.SetBool("IsOpen", true);
    }
}
