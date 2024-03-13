using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private float _interactionRange;
    [SerializeField] private LayerMask _interactionMask;
    [SerializeField] private Transform _headTransform;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;

        RaycastHit hit;
        if (!Physics.Raycast(_headTransform.position, _headTransform.forward, out hit, _interactionRange, _interactionMask)) return;

        IInteractable interactable;
        interactable = hit.collider.GetComponent<IInteractable>();
        
        if (interactable is null) return;

        interactable.Interact();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(_headTransform.position, _headTransform.position + _headTransform.forward * _interactionRange);
    }
}
