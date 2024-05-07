using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private InputSystem _inputSystem;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void FixedUpdate()
    {
        Fall();
    }

    private void OnEnable()
    {
        _inputSystem.FlyKeyDown += Fly;
    }

    private void OnDisable()
    {
        _inputSystem.FlyKeyDown -= Fly;
    }

    private void Fly()
    {
        _rigidBody.velocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }

    private void Fall()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidBody.velocity = Vector2.zero;
    }
}
