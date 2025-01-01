using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    private Rigidbody rb;
    private AudioSource audioSource;

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
