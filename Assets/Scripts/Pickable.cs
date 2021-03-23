using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private ResourceType _resource;
    [SerializeField] private int _amount = 1;

    private void OnTriggerEnter(Collider other) 
    {
        Resources.Instance.AddResource(_resource, _amount);
        Destroy(gameObject);
    }
}
