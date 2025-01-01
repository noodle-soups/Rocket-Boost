using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovementTest : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private float thrustPower;
    [SerializeField] private float rotationPower;

    // input actions
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

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
        HandleRotation();
    }

    private void HandleThrust()
    {
        float _thrustInput = thrust.ReadValue<float>();
        Vector3 _thrustVector = Vector3.up * _thrustInput;

        if (thrust.IsPressed())
        {
            Debug.Log("Thrust");
            Debug.Log(_thrustInput);
            rb.AddRelativeForce(_thrustVector * thrustPower * Time.fixedDeltaTime);
        }
    }

    private void HandleRotation()
    {
        float _rotationInput = -rotation.ReadValue<float>();
        Vector3 _rotationVector = Vector3.forward * _rotationInput;

        if (rotation.IsPressed())
        {
            Debug.Log("Rotation");
            rb.freezeRotation = true;
            transform.Rotate(_rotationVector * rotationPower * Time.fixedDeltaTime);
            rb.freezeRotation = false;
        }
    }

}
