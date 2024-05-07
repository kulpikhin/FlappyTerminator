using UnityEngine;
using UnityEngine.Pool;

public class PoolEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private ScoreCounter _scoreCounter;

    private int _poolCapacity = 5;
    private int _poolMaxSize = 5;

    private BoxCollider2D _collider;
    private ObjectPool<Enemy> _enemyPool;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _enemyPool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: (enemy) => ActionOnGet(enemy),
            actionOnRelease: (enemy) => ActionOnReleased(enemy),
            actionOnDestroy: (enemy) => Destroy(enemy),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public void GetEnemy()
    {
        _enemyPool.Get();
    }

    private void ActionOnGet(Enemy enemy)
    {
        enemy.FlewAway += _enemyPool.Release;
        enemy.Died += OnEnemyDied;
        enemy.gameObject.SetActive(true);
        enemy.transform.position = GetRandomPosition();
        enemy.Mover.EnterScene(enemy.transform.position);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _scoreCounter.Add();
        _enemyPool.Release(enemy);
    }

    private void ActionOnReleased(Enemy enemy)
    {
        enemy.FlewAway -= _enemyPool.Release;
        enemy.Died -= OnEnemyDied;
        enemy.gameObject.SetActive(false);
    }

    private Vector3 GetRandomPosition()
    {
        Bounds bounds = _collider.bounds;
        float ySpawnPosition = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector3(transform.position.x, ySpawnPosition, 0);
    }
}
