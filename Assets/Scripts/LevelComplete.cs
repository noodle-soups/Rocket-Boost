using UnityEngine;

public class LevelComplete : MonoBehaviour
{



    /*
     * LEVEL COMPLETE
     * Probably could be split into level complete & death sequence scripts
     */



    // cache
    private ShipMovement shipMovementScript;
    private AudioSource audioSource;
    private AudioManager audioManagerScript;

    // params
    public bool levelComplete;
    public bool playerDeath;

    private void Start()
    {
        shipMovementScript = GetComponent<ShipMovement>();

        audioSource = GetComponent<AudioSource>();
        audioManagerScript = GetComponent<AudioManager>();

        levelComplete = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Level Complete")
        {
            Debug.Log("Level Complete");
            if (!levelComplete) audioSource.PlayOneShot(audioManagerScript.sfxLevelComplete);
            levelComplete = true;
            shipMovementScript.enabled = false;
            // turn off SFX
        }

        if (collision.gameObject.tag == "Death")
        {
            Debug.Log("Death");
            if (!playerDeath) audioSource.PlayOneShot(audioManagerScript.sfxCrashExplosion);
            playerDeath = true;
            shipMovementScript.enabled = false;
            // turn off SFX
        }

    }

}
