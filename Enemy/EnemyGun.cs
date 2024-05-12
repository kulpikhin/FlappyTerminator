using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy), typeof(Collider2D))]
public class EnemyGun : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _bulletSpeed;

    private float _cooldawnDuration = 1.5f;
    private WaitForSeconds _waitSeconds;
    private Coroutine _shootCorutine;
    private Collider2D _collider2D;
    private bool _isActive = true;

    public BulletPool EnemyBulletPool { get; set; }

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _waitSeconds = new WaitForSeconds(_cooldawnDuration);
    }

    private void OnEnable()
    {
        StartShootCorutine();
    }

    private void OnDisable()
    {
        StopCoroutine(_shootCorutine);
    }

    private void Shoot()
    {
        Bullet bullet = EnemyBulletPool.GetBullet();
        bullet.transform.position = _gun.transform.position;
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), _collider2D);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * _bulletSpeed;
    }

    private void StartShootCorutine()
    {
        if(_shootCorutine != null)
        {
            StopCoroutine(_shootCorutine);
        }

        _shootCorutine = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while(_isActive)
        {
            yield return _waitSeconds;

            Shoot();
        }
    }
}
