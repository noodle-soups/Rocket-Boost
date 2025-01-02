using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    public bool levelComplete;
    public bool playerDeath;

    private void Start()
    {
        levelComplete = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Level Complete")
        {
            Debug.Log("Level Complete");
            levelComplete = true;
        }

        if (collision.gameObject.tag == "Death")
        {
            Debug.Log("Death");
            playerDeath = true;
        }

    }

}
