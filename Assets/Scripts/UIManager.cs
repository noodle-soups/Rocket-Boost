using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    // ui level over
    private GameObject uiLevelOver;
    private Button nextLevelButton;
    private string uiLevelOverName = "Level Over UI";
    private string uiNextLevelButtonName = "Next Level (Button)";

    // cache Player & associated scripts
    private GameObject player;
    private LevelComplete levelCompleteScript;
    private PlayerDeathManager playerDeathManagerscript;
    private string playerName = "Player";

    // params
    private int currentSceneIndex;
    private int nextSceneIndex;


    void Start()
    {
        // prep ui level over
        PrepUI();

        // player scripts
        player = GameObject.Find(playerName);
        playerDeathManagerscript = player.GetComponent<PlayerDeathManager>();

        // scene indicies
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;
    }


    #region Prep UI
    private void PrepUI()
    {
        // cache UI
        uiLevelOver = GameObject.Find(uiLevelOverName);

        // cache the buttons
        Transform _nextLevelButtonTransform = uiLevelOver.transform.Find(uiNextLevelButtonName);
        nextLevelButton = _nextLevelButtonTransform.GetComponent<Button>();

        // ensure UI is not active
        if (uiLevelOver == null)
            return;
        else
            uiLevelOver.SetActive(false);
    }
    #endregion


    #region Activate Level Over UI on Player Death or Level Complete
    public void ActivateLevelOverUI(bool _nextLevelVisible)
    {
        nextLevelButton.interactable = _nextLevelVisible;
        uiLevelOver.SetActive(true);
    }
    #endregion


    #region Load Scenes
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    #endregion


}
