using UnityEngine;
using System;

public class InputSystem : MonoBehaviour
{
    private KeyCode _shootKey = KeyCode.L;
    private KeyCode _flyKey = KeyCode.Space;

    public event Action ShootKeyDown;
    public event Action FlyKeyDown;

    private void Update()
    {
        GetKey();
    }    

    private void GetKey()
    {
        if(Input.GetKeyDown(_flyKey))
        {
            FlyKeyDown?.Invoke();
        }

        if (Input.GetKeyDown(_shootKey))
        {
            ShootKeyDown?.Invoke();
        }
    }
}
