using UnityEngine;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{
    public event UnityAction ShootKeyDown;
    public event UnityAction FlyKeyDown;

    private void Update()
    {
        GetKey();
    }

    private void GetKey()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FlyKeyDown?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            ShootKeyDown?.Invoke();
        }
    }
}
