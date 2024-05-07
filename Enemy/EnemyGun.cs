using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyGun : MonoBehaviour
{
    [SerializeField] Gun _gun;
    [SerializeField] Bullet _bullet;
    [SerializeField] float _bulletSpeed;

    private float _cooldawnDuration = 1.5f;
    private WaitForSeconds _waitSeconds;
    private Coroutine _shootCorutine;
    private bool _isActive = true;

    private void Awake()
    {
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
        Bullet bullet = Instantiate(_bullet, _gun.transform.position, Quaternion.identity);
        bullet.IsPlayerShoot = false;
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * _bulletSpeed;
    }

    private void StartShootCorutine()
    {
        if(_shootCorutine != null)
        {
            StopCoroutine(_shootCorutine);
        }

        _shootCorutine = StartCoroutine(ShootCorutine());
    }

    private IEnumerator ShootCorutine()
    {
        while(_isActive)
        {
            yield return _waitSeconds;

            Shoot();
        }
    }
}
