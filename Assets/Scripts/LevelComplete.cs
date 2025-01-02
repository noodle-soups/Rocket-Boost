using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    public bool levelComplete;

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
    }

}
