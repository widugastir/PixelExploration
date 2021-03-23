using UnityEngine;

public class ConstantTorque : MonoBehaviour
{
    [SerializeField] private Vector3 _torque;

    private void Update()
    {
        transform.Rotate(_torque * Time.deltaTime, Space.World);
    }
}
