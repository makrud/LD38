using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private Timer timerComponent;
    private ReloadCurrentLevel reloadLvl;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject gameOverLabel;
    [SerializeField]
    private GameObject youWinLabel;
    [SerializeField]
    private GameObject retryBtnObject;
    private GameObject Suicider;
    SuiciderController sc;
    float timeScaleOnStart;
    // Use this for initialization
    void Start()
    {
        Suicider = GameObject.FindGameObjectWithTag("Suicider");
        sc = Suicider.GetComponent<SuiciderController>();
        timerComponent = this.GetComponent<Timer>();
        gameOverLabel.SetActive(false);
        retryBtnObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sc.isRescued && !youWinLabel.activeSelf)
        {
            PauseGame();
            ActivateTextLabel(youWinLabel);
            ActivateButton(retryBtnObject);
        }
        if (timerComponent.timeLeft < 0 && !gameOverLabel.activeSelf)
        {
            if (sc.isDead)
            {
                PauseGame();
                ActivateTextLabel(gameOverLabel);
                ActivateButton(retryBtnObject);
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0; // pause game
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
    void ActivateTextLabel(GameObject label)
    {
        label.SetActive(true);
    }
    void ActivateButton(GameObject btn)
    {
        btn.SetActive(true);
    }
}
