using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(PlayerCollisionHandler))]
[RequireComponent (typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerCollisionHandler _collisionHandler;
    private PlayerMover _mover;

    public event UnityAction GameOver;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _mover.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is Scope)
        {
            GameOver?.Invoke();
        }

        if(interactable is Bullet bullet)
        {
            if(!bullet.IsPlayerShoot)
            {
                GameOver?.Invoke();
            }
        }
    }
}
