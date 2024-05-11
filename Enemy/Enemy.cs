using UnityEngine;
using System;

[RequireComponent(typeof(EnemyMover), typeof(EnemyCollisionHandler), typeof(EnemyGun))]
public class Enemy : MonoBehaviour
{
    private EnemyCollisionHandler _collisionHandler;
    private EnemyGun _enemyGun;

    public event Action<Enemy> FlewAway;
    public event Action<Enemy> Died;

    public EnemyMover Mover { get; private set; }

    private void Awake()
    {
        _enemyGun = GetComponent<EnemyGun>();
        Mover = GetComponent<EnemyMover>();
        _collisionHandler = GetComponent<EnemyCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void SetBulletPool(BulletPool bulletPool)
    {
        _enemyGun.EnemyBulletPool = bulletPool;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (Mover.IsEnterScene)
        {
            if (interactable is Scope)
            {
                FlewAway?.Invoke(this);
            }
            else if (interactable is Bullet bullet)
            {
                Died?.Invoke(this);
            }
        }
    }
}
