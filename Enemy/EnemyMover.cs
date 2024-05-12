using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _entryDistance = 1f;
    private Coroutine _moveCorutine;

    public bool IsEnterScene { get; private set; }

    private void OnDisable()
    {
        IsEnterScene = false;

        if (_moveCorutine != null)
        {
            StopCoroutine(_moveCorutine);
        }
    }

    public void EnterScene(Vector3 startPosition)
    {
        StartMoveCorutine(startPosition - new Vector3(_entryDistance, 0, 0));
    }

    private void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void StartMoveCorutine(Vector3 target)
    {
        if (_moveCorutine != null)
        {
            StopCoroutine(_moveCorutine);
        }

        _moveCorutine = StartCoroutine(Moving(target));
    }

    private IEnumerator Moving(Vector3 target)
    {
        while (!IsEnterScene)
        {
            Move(target);

            if (transform.position == target)
                IsEnterScene = true;

            yield return null;
        }
    }
}
