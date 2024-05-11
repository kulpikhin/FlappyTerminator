using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(PoolEnemies))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;

    private float _spawnCooldawn = 3f;
    private PoolEnemies _poolEnemies;
    private Coroutine _spawnCoroutine;
    private WaitForSeconds _waitSeconds;
    private bool _isActive = true;

    private void Awake()
    {
        _poolEnemies = GetComponent<PoolEnemies>();
        _waitSeconds = new WaitForSeconds(_spawnCooldawn);
    }

    private void Start()
    {
        StartSpawnCorutine();
    }

    private void StartSpawnCorutine()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }

        _spawnCoroutine = StartCoroutine(SpawnCorutine());
    }

    private IEnumerator SpawnCorutine()
    {
        while (_isActive)
        {
            Enemy enemy = _poolEnemies.GetEnemy();
            enemy.SetBulletPool(_bulletPool);

            yield return _waitSeconds;
        }
    }
}
