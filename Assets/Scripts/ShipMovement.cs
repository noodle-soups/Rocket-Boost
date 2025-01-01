using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;
    private Rigidbody rb;
    [SerializeField] private float thrustPower;

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleThrust();

        float _rotationInput = rotation.ReadValue<float>();
        if (rotation.IsPressed())
        {
            Debug.Log("Rotation");
            Debug.Log(_rotationInput);
        }
    }

    private void HandleThrust()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Thrust");
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.fixedDeltaTime);
        }
    }
}
