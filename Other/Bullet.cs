using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    public bool IsPlayerShoot {  get;  set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Scope scope))
        {
            Destroy(gameObject);
        }
        else if (IsPlayerShoot && collision.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject);
        }
        else if(!IsPlayerShoot && collision.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
        }
    }
}
