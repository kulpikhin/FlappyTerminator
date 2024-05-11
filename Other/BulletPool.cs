using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    private ObjectPool<Bullet> _bulletPool;
    private int _poolCapacity = 20;
    private int _poolMaxSize = 20;

    private void Awake()
    {
        _bulletPool = new ObjectPool<Bullet>(
         createFunc: () => Instantiate(_bulletPrefab),
         actionOnGet: (bullet) => ActionOnGet(bullet),
         actionOnRelease: (bullet) => ActionOnRelease(bullet),
         actionOnDestroy: (bullet) => Destroy(bullet),
         collectionCheck: true,
         defaultCapacity: _poolCapacity,
         maxSize: _poolMaxSize);
    }

    public Bullet GetBullet()
    {
        return _bulletPool.Get();
    }

    private Bullet ActionOnGet(Bullet bullet)
    {
        bullet.Destroyed += OnBulletDestroyed;
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    private void ActionOnRelease(Bullet bullet)
    {
        bullet.Destroyed -= OnBulletDestroyed;
        bullet.gameObject.SetActive(false);

    }

    private void OnBulletDestroyed(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }
}
