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
    private SfxManager sfxManagerScript;
    private VfxManager vfxManagerScript;

    // params
    public bool levelComplete;
    public bool playerDeath;

    private void Start()
    {
        shipMovementScript = GetComponent<ShipMovement>();

        audioSource = GetComponent<AudioSource>();
        sfxManagerScript = GetComponent<SfxManager>();
        vfxManagerScript = GetComponent<VfxManager>();

        levelComplete = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Level Complete")
        {
            Debug.Log("Level Complete");
            if (!levelComplete) 
            { 
                audioSource.PlayOneShot(sfxManagerScript.sfxLevelComplete); 
                vfxManagerScript.vfxLevelComplete.Play();
            }
            levelComplete = true;
            shipMovementScript.enabled = false;
        }

        if (collision.gameObject.tag == "Death")
        {
            Debug.Log("Death");
            if (!playerDeath) 
            {
                audioSource.PlayOneShot(sfxManagerScript.sfxCrashExplosion);
                vfxManagerScript.vfxCrashExplosion.Play();
            }
            playerDeath = true;
            shipMovementScript.enabled = false;
        }

    }

}
