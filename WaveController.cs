using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    GameObject[] spawners;
    SoulSpawn sp;
    int currentWave;
    GameManager gm;

    public GameObject nextWaveNumber;
    public GameObject nextWaveLabel;

    public Text nextWaveNumberText;
    public Text nextWaveLabelText;

    public GameObject typerGameObject;
    private TextTyper textTyper;

    TreeHealth th;



    // Use this for initialization
    void Start()
    {
        th = GameObject.FindGameObjectWithTag("Tree").GetComponent<TreeHealth>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spawners = GameObject.FindGameObjectsWithTag("SoulSpawner");

        textTyper = typerGameObject.GetComponent<TextTyper>();
        nextWaveLabelText = nextWaveLabel.GetComponent<Text>();
        nextWaveNumberText = nextWaveNumber.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        nextWaveLabel.SetActive(true);
        nextWaveNumber.SetActive(true);
        if (gm.shouldPlayNextWave)
        {
            //aktywuj text WAVE NR INCOMING
            PlayNextWave();
            gm.shouldPlayNextWave = false;
        }
        if (gm.allEvilSoulsLeft.Length > 0)
        {
            gm.currentWaveDone = false;
        }
    }

    void PlayNextWave()
    {
        SoulSpawn sp = GameObject.FindGameObjectWithTag("SoulSpawner").GetComponent<SoulSpawn>();
        gm.waveCounter = gm.waveCounter + 1;
        switch (gm.waveCounter)
        {
            case 1:
                //AddMobs(5, 10);
                textTyper.message = "Wave 1";
                if (!textTyper.CR_isRunning)
                {
                    textTyper.startTextCoroutine(4);
                }
                break;
            case 2:
                HealTree();
                AddMobs(20, 40);
                textTyper.message = "Wave 2, Tree's healt will be updated";
                if (!textTyper.CR_isRunning)
                {
                    textTyper.startTextCoroutine(4);
                }
                break;
            case 3:
                HealTree();
                AddMobs(40, 70);
                textTyper.message = "Wave 3, Tree's healt will be updated";
                if (!textTyper.CR_isRunning)
                {
                    textTyper.startTextCoroutine(4);
                }
                int index = 0;
                foreach (GameObject enemy in sp.SoulsArray)
                {
                    sp.SoulsArray[index] = sp.SoulEvilBig;
                    index++;
                }
                break;
            case 4:
                HealTree();
                AddMobs(70, 120);
                textTyper.message = "Wave 4, Tree's healt will be updated";
                if (!textTyper.CR_isRunning)
                {
                    textTyper.startTextCoroutine(4);
                }
                foreach (GameObject enemy in sp.SoulsArray)
                {
                    sp.startTimer = 1.8f;
                }
                break;
            case 5:
                HealTree();
                AddMobs(120, 200);
                textTyper.message = "Wave 5, Tree's healt will be updated";
                if (!textTyper.CR_isRunning)
                {
                    textTyper.startTextCoroutine(4);
                }
                foreach (GameObject enemy in sp.SoulsArray)
                {
                    SoulController scBig = sp.SoulEvilBig.GetComponent<SoulController>();
                    scBig.currentHealth = 100;
                    scBig.enemyDmgToTree = 50;
                    SoulController scSmall = sp.SoulEvil.GetComponent<SoulController>();
                    scBig.currentHealth = 60;
                    scBig.enemyDmgToTree = 25;
                    sp.startTimer = 0.9f;
                }
                break;
            case 6:
                HealTree();
                AddMobs(200, 400);
                textTyper.message = "Wave 6, Tree's healt will be updated";
                if (!textTyper.CR_isRunning)
                {
                    textTyper.startTextCoroutine(4);
                }
                break;
            default:
                AddMobs(320, 1000);
                break;
        }
    }

    void AddMobs(int minMobs, int maxMobs)
    {
        foreach (GameObject spawner in spawners)
        {
            SoulSpawn sp = spawner.GetComponent<SoulSpawn>();
            int amount = Random.Range(minMobs, maxMobs);
            sp.currentSoulsAmount = amount;
            sp.shouldSpawn = true;
        }
    }
    void HealTree()
    {
        th.currentHealth = th.startingHealth;
    }
}
