using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    [SerializeField] private InputAction thrust;
    private Rigidbody rb;
    [SerializeField] private float thrustPower;

    private void OnEnable()
    {
        thrust.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Thrust");
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.fixedDeltaTime);
        }
    }

}
