using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] float _xOffset;

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 position = transform.position;
        position.x = _player.transform.position.x + _xOffset;
        transform.position = position;
    }
}
