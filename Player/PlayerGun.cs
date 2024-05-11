using UnityEngine;

[RequireComponent(typeof(Player) , typeof(Collider2D))]
public class PlayerGun : MonoBehaviour
{
    [SerializeField] InputSystem _inputSystem;
    [SerializeField] Gun _gun;
    [SerializeField] Bullet _bullet;
    [SerializeField] float _bulletSpeed;
    [SerializeField] BulletPool _bulletPool;

    private Collider2D _collider2D;
    private Vector2 _direction;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _inputSystem.ShootKeyDown += Shoot;
    }

    private void OnDisable()
    {
        _inputSystem.ShootKeyDown -= Shoot;
    }

    private void Shoot()
    {
        _direction = transform.right;
        Bullet bullet = _bulletPool.GetBullet();
        bullet.transform.position = _gun.transform.position;
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), _collider2D);
        bullet.GetComponent<Rigidbody2D>().velocity = _direction * _bulletSpeed;
    }
}
