using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovementTest : MonoBehaviour
{

    // cache
    private Rigidbody rb;
    private RigidbodyConstraints rbDefaultConstraints;
    private AudioSource audioSource;
    private SfxManager sfxManagerScript;
    private VfxManager vfxManagerScript;

    // params - movement
    [SerializeField] private float thrustPower;
    [SerializeField] private float rotationPower;

    // params - Input Actions
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

    //
    [SerializeField] private AudioClip sfxMainEngineThrust;

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbDefaultConstraints = rb.constraints;
        audioSource = GetComponent<AudioSource>();
        sfxManagerScript = GetComponent<SfxManager>();
        vfxManagerScript = GetComponent<VfxManager>();

    }

    private void FixedUpdate()
    {
        HandleThrust();
        HandleRotation();
    }


    #region Thrust
    private void HandleThrust()
    {
        Vector2 _thrustInputVector = thrust.ReadValue<Vector2>();

        // handle thrust
        if (thrust.IsPressed())
        {
            OnStartThrust(_thrustInputVector);
        }
        else
        {
            OnStopThrust();
        }



    }

    private void OnStartThrust(Vector3 _thrustInputVector)
    {
        // apply force
        rb.AddRelativeForce(_thrustInputVector * thrustPower * Time.fixedDeltaTime);

        // SFX
        if (!audioSource.isPlaying) audioSource.PlayOneShot(sfxManagerScript.sfxMainEngineThrust);

        // VFX
        vfxManagerScript.vfxMainEngineThrust.Play();
    }

    private void OnStopThrust()
    {
        // SFX
        audioSource.Stop();

        // VFX
        vfxManagerScript.vfxMainEngineThrust.Stop();
    }
    #endregion


    #region Rotation
    private void HandleRotation()
    {
        // cache inputs
        float _rotationInput = -rotation.ReadValue<float>();
        Vector3 _rotationVector = Vector3.forward * _rotationInput;

        // handle rotation
        if (rotation.IsPressed())
        {
            OnStartRotation(_rotationInput, _rotationVector);
        }
        else
        {
            OnStopRotation();
        }
    }

    private void OnStartRotation(float _rotationInput, Vector3 _rotationVector)
    {
        // prevent physics interfering with player rotation
        // add Z rotation freeze to rb.constraints
        rb.constraints |= RigidbodyConstraints.FreezeRotationZ;

        // apply rotation
        transform.Rotate(_rotationVector * rotationPower * Time.fixedDeltaTime);

        // revert to rb.constraints
        rb.constraints = rbDefaultConstraints;

        // vfx
        if (_rotationInput > 0f)
            vfxManagerScript.vfxSideEngineThrustR.Play();
        else if (_rotationInput < 0f)
            vfxManagerScript.vfxSideEngineThrustL.Play();
    }

    private void OnStopRotation()
    {
        vfxManagerScript.vfxSideEngineThrustR.Stop();
        vfxManagerScript.vfxSideEngineThrustL.Stop();
    }
    #endregion

}
