using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    /* UI MANAGER
     * 
     * Script to hide / unhide UIs
     * Also houses UI methods like loading scenes
     * 
     */


    // cache child UIs
    private GameObject uiLevelOver;
    private Button nextLevelButton;

    // cache scene index
    private int currentSceneIndex;
    private int nextSceneIndex;

    // reference Player & associated scripts
    [SerializeField] private GameObject player;
    private LevelComplete levelCompleteScript;

    void Start()
    {
        // cache Level Over UI & make sure it is inactive
        uiLevelOver = GameObject.Find("Level Over UI");
        DeactivateLevelOverUIOnStart();

        Transform _nextLevelButtonTransform = uiLevelOver.transform.Find("Next Level (Button)");
        nextLevelButton = _nextLevelButtonTransform.GetComponent<Button>();

        // cache the Level Complete script
        // we need the levelComplete bool to know when to activate UIs
        levelCompleteScript = player.GetComponent<LevelComplete>();

        // cache scene indicies
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex+1;
    }

    private void Update()
    {
        ActivateLevelOverUI();
    }

    private void DeactivateLevelOverUIOnStart()
    {
        if (uiLevelOver == null)
            return;
        else
            uiLevelOver.SetActive(false);
    }

    private void ActivateLevelOverUI()
    {
        if (levelCompleteScript.levelComplete)
            uiLevelOver.SetActive(true);

        if (levelCompleteScript.playerDeath)
        {
            uiLevelOver.SetActive(true);
            // make "Next Level (Button)" button not interactable
            // "Next Level (Button)" is a child of uiLevelOver
            nextLevelButton.interactable = false;
        }
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

}
