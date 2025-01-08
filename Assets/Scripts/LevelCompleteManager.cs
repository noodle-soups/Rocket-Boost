using UnityEngine;

public class LevelCompleteManager : MonoBehaviour
{

    // components
    private AudioSource audioSource;

    // ui
    private GameObject ui;
    private UIManager uiManagerScript;

    // player scripts
    private ShipMovement shipMovementScript;
    private SfxManager sfxManagerScript;
    private VfxManager vfxManagerScript;

    // level complete state
    public bool levelComplete = false;
    public bool levelCompleteSequencePlayed = false;

    private void Start()
    {
        // ui
        ui = GameObject.Find("UI");
        uiManagerScript = ui.GetComponent<UIManager>();

        // player scripts
        audioSource = GetComponent<AudioSource>();
        shipMovementScript = GetComponent<ShipMovement>();
        sfxManagerScript = GetComponent<SfxManager>();
        vfxManagerScript = GetComponent<VfxManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Level Complete")
        {
            levelComplete = true;
            OnLevelCompleteStart();
        }
    }

    private void OnLevelCompleteStart()
    {
        Debug.Log("Level Complete");
        shipMovementScript.enabled = false;

        if (!levelCompleteSequencePlayed)
        {
            audioSource.PlayOneShot(sfxManagerScript.sfxLevelComplete);
            vfxManagerScript.vfxLevelComplete.Play();
        }
        levelCompleteSequencePlayed = true;

        uiManagerScript.ActivateLevelOverUI(true);
    }

}
