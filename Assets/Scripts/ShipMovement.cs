using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private float thrustPower;
    [SerializeField] private float rotationPower;
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

    [SerializeField] private float gravityValue;

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravityValue, 0);
    }

    private void FixedUpdate()
    {
        HandleThrust();
        HandleRotation();
    }

    private void HandleThrust()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Thrust");
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.fixedDeltaTime);
        }
    }

    private void HandleRotation()
    {
        float _rotationInput = -rotation.ReadValue<float>();
        Vector3 _rotationVector = new Vector3(0, 0, _rotationInput);

        if (rotation.IsPressed())
        {
            Debug.Log("Rotation");
            rb.freezeRotation = true;
            transform.Rotate(_rotationVector * rotationPower * Time.fixedDeltaTime);
            rb.freezeRotation = false;
        }
    }


}
