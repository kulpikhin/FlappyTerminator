using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PoolEnemies))]
public class EnemySpawner : MonoBehaviour
{
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
            _poolEnemies.GetEnemy();

            yield return _waitSeconds;
        }
    }
}
