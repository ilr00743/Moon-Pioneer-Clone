using Player;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private PlayerMovement _target;
    [SerializeField] private float _followingSpeed;
    private Vector3 _offset;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _offset = _transform.position - _target.Transform.position;
    }

    private void LateUpdate()
    {
        var targetPosition =
            new Vector3(_target.Transform.position.x, _target.Transform.position.y, _target.Transform.position.z) +
            _offset;
        _transform.position = Vector3.Lerp(_transform.position, targetPosition, _followingSpeed * Time.deltaTime);
    }
}