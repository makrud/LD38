using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadCurrentLevel :MonoBehaviour
{
    private SceneManager SceneManager;
    private GameOver go;
    Scene actualScene;
    public Button RetryBtn;
    // Use this for initialization
    void Start()
    {
        go = GetComponent<GameOver>();
        actualScene = SceneManager.GetActiveScene();
        Button btn = RetryBtn.GetComponent<Button>();
        btn.onClick.AddListener(ReloadActualScene);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void ReloadActualScene() {
        go.UnPauseGame();
        SceneManager.LoadScene(actualScene.name);

    }
}
