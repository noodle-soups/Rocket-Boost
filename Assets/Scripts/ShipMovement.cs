using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    [SerializeField] private InputAction thrust;

    private void OnEnable()
    {
        thrust.Enable();
    }

    private void Update()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Thrust");
        }
    }

}
