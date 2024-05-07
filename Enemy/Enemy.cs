using UnityEngine;
using System;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyCollisionHandler))]
public class Enemy : MonoBehaviour
{
    private EnemyCollisionHandler _collisionHandler;

    public event Action<Enemy> FlewAway;
    public event Action<Enemy> Died;

    public EnemyMover Mover { get; private set; }

    private void Awake()
    {
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
                if (bullet.IsPlayerShoot)
                {
                    Died?.Invoke(this);
                }
            }
        }
    }
}
