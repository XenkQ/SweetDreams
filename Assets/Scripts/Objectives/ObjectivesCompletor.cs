using UnityEngine;

[RequireComponent(typeof(IInteractable))]
public class ObjectivesCompletor : MonoBehaviour, IObjectiveOwner
{
    [SerializeField] private int _objectiveId;
    public int ObjectiveID => _objectiveId;
    private IInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<IInteractable>();
    }

    private void Start()
    {
        interactable.interactionEvent.AddListener(CompleteObjective);
    }

    public void CompleteObjective()
    {
        ObjectivesManager.EndObjective(ObjectiveID, true);
    }
}
