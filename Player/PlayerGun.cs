using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerGun : MonoBehaviour
{
    [SerializeField] InputSystem _inputSystem;
    [SerializeField] Gun _gun;
    [SerializeField] Bullet _bullet;
    [SerializeField] float _bulletSpeed;

    private Vector2 _direction;

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
        Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        bullet.IsPlayerShoot = true;
        bullet.GetComponent<Rigidbody2D>().velocity = _direction * _bulletSpeed;
    }
}
