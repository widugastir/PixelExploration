using UnityEngine.UI;
using UnityEngine;

public class ResourceAmountUI : MonoBehaviour
{
    [SerializeField] private ResourceType _resourceType;
    private Text _text;

    private void Awake() => _text = GetComponent<Text>();
    private void OnEnable() => Resources.OnResourceChange += OnResourceChange;
    private void OnDisable() => Resources.OnResourceChange -= OnResourceChange;
    
    private void OnResourceChange(ResourceType type, int amount) 
    {
        if(type == _resourceType)
        {
            _text.text = $"{amount}";
        }
    }
}
