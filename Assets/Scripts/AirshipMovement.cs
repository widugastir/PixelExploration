using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AirshipMovement : MonoBehaviour
{
    [SerializeField] private float _reverseThrustCooldown;
    [SerializeField] private float _reverseThrustForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rigi;
    private float _vertical;
    private float _horizontal;
    private float _reverseCooldown;

    private void Start() {
        _rigi = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _vertical = Input.GetAxisRaw("Vertical");
        _horizontal = Input.GetAxisRaw("Horizontal");
        ReverseThrust();
    }

    private void FixedUpdate() {
        MoveForward();
        Rotate();
    }

    private void MoveForward()
    {
        if(_vertical > 0f)
        {
            _rigi.AddForce(transform.forward * _speed * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        if(_horizontal != 0f)
        {
            _rigi.AddTorque(transform.up * _horizontal * _rotateSpeed * Time.deltaTime);
        }
    }
    
    private void ReverseThrust()
    {
        if(_reverseCooldown < _reverseThrustCooldown)
            _reverseCooldown += Time.deltaTime;
        if(Input.GetKey(KeyCode.S))
        {
            if(_reverseCooldown > _reverseThrustCooldown)
            {
                _reverseCooldown = 0f;
                _rigi.AddForce(-transform.forward * _reverseThrustForce);
            }
        }
    }
}
