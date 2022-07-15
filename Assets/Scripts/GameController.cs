using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;    
    public TextMeshProUGUI timer;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI activeScene;
    private float levelTime = 20f;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        activeScene.text = "Level : " + (SceneManager.GetActiveScene().buildIndex + 1).ToString("0");
    }
    public void GameEnded(bool end)
    {
        if (end) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    private void Update()
    {
        levelTime -= Time.deltaTime;
        timer.text = "Time : " + levelTime.ToString("0");
        if(levelTime <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
