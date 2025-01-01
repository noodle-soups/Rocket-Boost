using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    private Rigidbody rb;
    private AudioSource audioSource;
    private RigidbodyConstraints rbDefaultConstraints;

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
        audioSource = GetComponent<AudioSource>();

        rbDefaultConstraints = rb.constraints;
    }

    private void FixedUpdate()
    {
        HandleThrust();
        HandleRotation();
    }

    private void HandleThrust()
    {
        // cache inputs
        float _thrustInput = thrust.ReadValue<float>();
        Vector3 _thrustVector = Vector3.up * _thrustInput;

        // handle thrust
        if (thrust.IsPressed())
        {
            // apply force
            Debug.Log("Thrust");
            rb.AddRelativeForce(_thrustVector * thrustPower * Time.fixedDeltaTime);

            // play SFX
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else 
        {
            // stop SFX
            audioSource.Stop();
        }
    }

    private void HandleRotation()
    {
        // cache inputs
        float _rotationInput = -rotation.ReadValue<float>();
        Vector3 _rotationVector = Vector3.forward * _rotationInput;

        // handle rotation
        if (rotation.IsPressed())
        {
            Debug.Log("Rotation");

            // prevent physics interfering with player rotation
            // add Z rotation freeze to rb.constraints
            rb.constraints |= RigidbodyConstraints.FreezeRotationZ;

            // apply rotation
            transform.Rotate(_rotationVector * rotationPower * Time.fixedDeltaTime);

            // revert to rb.constraints
            rb.constraints = rbDefaultConstraints;
        }
    }

}
