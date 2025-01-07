using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    // cache
    private Rigidbody rb;
    private AudioSource audioSource;
    private SfxManager sfxManagerScript;
    private VfxManager vfxManagerScript;

    // params - movement
    [Header("Movement")]
    [SerializeField] private float thrustPower;
    [SerializeField] private float boostPower;
    [SerializeField] private float boostCooldown;
    [SerializeField] private bool boostReady = true;

    // params - Input Actions
    [Header("Input Actions")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction boost;
    private Vector2 thrustInput;

    [Header("SFX")]
    [SerializeField] private AudioClip sfxMainEngineThrust;


    #region Execution Order
    private void OnEnable()
    {
        thrust.Enable();
        boost.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        sfxManagerScript = GetComponent<SfxManager>();
        vfxManagerScript = GetComponent<VfxManager>();
    }

    private void FixedUpdate()
    {
        HandleThrust();
        HandleBoost();
    }
    #endregion


    #region Thrust
    private void HandleThrust()
    {
        // cache input
        thrustInput = thrust.ReadValue<Vector2>();

        // handle thrust
        if (thrust.IsPressed())
        {
            OnStartThrust();
        }
        else
        {
            OnStopThrust();
        }
    }

    private void OnStartThrust()
    {
        // apply force
        rb.AddRelativeForce(thrustInput * thrustPower * Time.fixedDeltaTime);

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


    #region Boost
    private void HandleBoost()
    {
        if (boost.IsPressed() && boostReady)
        {
            rb.AddForce(thrustInput * boostPower * Time.fixedDeltaTime, ForceMode.Impulse);
            boostReady = false;
            Invoke(nameof(ResetBoost), boostCooldown);
        }
    }

    private void ResetBoost()
    {
        boostReady = true;
    }
    #endregion

}
