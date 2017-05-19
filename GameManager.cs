using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject WaveFinished;
    public bool shouldPlayNextWave = false;
    public int waveCounter = 0;

    public GameObject scoreText;
    private Text scoreTextComp;
    public GameObject youLost;
    public float score = 0f;

    public bool currentWaveDone = false;
    public GameObject evilsGameObject;
    private Text evilsTextComp;
    public int evilsCount = 0;

    public GameObject QuitButton;

    public bool flagOnce = false;

    public GameObject SoulSpawner;
    GameObject[] spawners;

    public GameObject[] allEvilSoulsLeft;

    public SoulSpawn sp;

    public TreeHealth th;

    public bool canQuit = false;

    public bool CR_Running = false;

    public bool oneDone = false, twoDone = false, threeDone = false, fourDone = false, fiveDone = false, sixDone = false;
    // Use this for initialization

    private void Start()
    {
        waveCounter = 1;
        scoreTextComp = scoreText.GetComponent<Text>();
        evilsTextComp = evilsGameObject.GetComponent<Text>();
        sp = SoulSpawner.GetComponent<SoulSpawn>();
        th = GameObject.FindGameObjectWithTag("Tree").GetComponent<TreeHealth>();
        spawners = GameObject.FindGameObjectsWithTag("SoulSpawner");
        canQuit = false;
    }

    // Update is called once per frame
    void Update()
    {
        allEvilSoulsLeft = GameObject.FindGameObjectsWithTag("Enemy");
        evilsCount = sp.currentSoulsAmount * spawners.Length;
        if (evilsCount > 0)
        {
            evilsTextComp.text = evilsCount.ToString();
        }
        else
        {
            evilsTextComp.text = "0";
        }

        if (score >= 0)
        {
            scoreTextComp.text = score.ToString();
        }

        if (sp.currentSoulsAmount <= 0 && allEvilSoulsLeft.Length <= 0)
        {
            currentWaveDone = true;
            if (currentWaveDone)
            {
                shouldPlayNextWave = true;
            }
            //StartCoroutine(ActivateWaveText());
            flagOnce = true;
        }
        if (th.currentHealth <= 0)
        {
            Time.timeScale = 0;
            youLost.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(2);
                Time.timeScale = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canQuit == true)
            {
                canQuit = false;
            }
            else
            {
                canQuit = true;
            }
        }
        if (canQuit == true)
        {
            QuitButton.SetActive(true);
        }
        else
        {
            QuitButton.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator ActivateWaveText()
    {
        CR_Running = true;
        WaveFinished.SetActive(true);
        yield return 0;
        yield return new WaitForSeconds(3);
        WaveFinished.SetActive(false);
        shouldPlayNextWave = true;
        CR_Running = false;
    }
}
