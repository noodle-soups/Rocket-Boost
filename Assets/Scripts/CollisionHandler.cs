using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log(collision.gameObject.tag);
                break;
            case "Finish":
                Debug.Log(collision.gameObject.tag);
                break;
            case "Fuel":
                Debug.Log(collision.gameObject.tag);
                break;
            default:
                Debug.Log("Crash");
                ReloadCurrentScene();
                break;
        }
    }

    private void ReloadCurrentScene()
    {
        int _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentSceneIndex);
    }
}
