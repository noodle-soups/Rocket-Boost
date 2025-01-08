using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{

    // components
    private AudioSource audioSource;

    // ui
    private GameObject ui;
    private UIManager uiManagerScript;

    // player scripts
    private PlayerHealthManager playerHealthManagerScript;
    private ShipMovement shipMovementScript;
    private SfxManager sfxManagerScript;
    private VfxManager vfxManagerScript;

    // death state
    public bool playerDead = false;
    private bool deathSequencePlayed = false;

    private void Start()
    {
        // ui
        ui = GameObject.Find("UI");
        uiManagerScript = ui.GetComponent<UIManager>();

        // player scripts
        audioSource = GetComponent<AudioSource>();
        playerHealthManagerScript = GetComponent<PlayerHealthManager>();
        shipMovementScript = GetComponent<ShipMovement>();
        sfxManagerScript = GetComponent<SfxManager>();
        vfxManagerScript = GetComponent<VfxManager>();
    }

    private void Update()
    {
        CheckDeathState();
        OnDeathStart();
    }

    private void CheckDeathState()
    {
        if (playerHealthManagerScript.playerHP <= 0f)
        {
            playerDead = true;
        }
    }

    private void OnDeathStart()
    {
        if (!playerDead)
        {
            return;
        }
        else if (playerDead)
        {
            Debug.Log("Player is dead");
            shipMovementScript.enabled = false;

            if (!deathSequencePlayed)
            {
                audioSource.PlayOneShot(sfxManagerScript.sfxCrashExplosion);
                vfxManagerScript.vfxCrashExplosion.Play();
            }

            deathSequencePlayed = true;
            uiManagerScript.ActivateLevelOverUI(false);
        }
    }


}
