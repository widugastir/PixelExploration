using UnityEngine;
using DG.Tweening;

public class LensCullingScaler : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _target;
    [SerializeField] private LayerMask _obstacleMask;

    private bool _disabled = true;

    private void Update() 
    {
        ScaleLens();
    }

    private void ScaleLens()
    {
        Vector3 direction = _target.position - _camera.position;
        if(Physics.Raycast(_camera.position, direction.normalized, direction.magnitude, _obstacleMask))
        {
            if (_disabled == true)
            {
                transform.DOScale(1f, 0.5f);
                _disabled = false;
            }
        }
        else
        {
            if (_disabled == false)
            {
                transform.DOScale(0f, 1f);
                _disabled = true;
            }
        }
    }
}