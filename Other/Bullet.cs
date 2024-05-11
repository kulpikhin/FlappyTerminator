using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    public event Action<Bullet> Destroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Scope scope) || collision.TryGetComponent(out Enemy enemy) || collision.TryGetComponent(out Player player))
        {
            Destroyed?.Invoke(this);
        }
    }
}
