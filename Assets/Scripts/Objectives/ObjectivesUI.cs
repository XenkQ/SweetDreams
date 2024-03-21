using TMPro;
using UnityEngine;

public class ObjectivesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;

    public void Refresh(Objective objective)
    {
        _name.text = objective.Name;
        _description.text = objective.Description;
    }
}
