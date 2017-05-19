using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulSpawn : MonoBehaviour
{
    public GameObject SoulGood;
    public GameObject SoulEvil;
    public GameObject SoulEvilBig;


    public GameObject[] SoulsArray;
    int index;
    public float Timer = 2.5f;
    public int SoulsAmount = 5;
    public int currentSoulsAmount;
    public float startTimer;

    public bool shouldSpawn;
    // Use this for initialization
    void Start()
    {
        startTimer = Timer;
        SoulsArray[0] = SoulGood;
        SoulsArray[1] = SoulEvil;
        if (SoulEvilBig != null)
        {
            SoulsArray[2] = SoulEvilBig;
        }
        else
        {
            SoulsArray[2] = SoulGood;
        }
        shouldSpawn = true;
        currentSoulsAmount = SoulsAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSoulsAmount == 0)
        {
            shouldSpawn = false;
            StopCoroutine(SpawnSoul(PickedSoulToSpawn()));
        }
        Timer -= Time.deltaTime;
        if (Timer <= 0f && shouldSpawn)
        {
            StartCoroutine(SpawnSoul(PickedSoulToSpawn()));
            Timer = startTimer;
        }
    }

    IEnumerator SpawnSoul(GameObject soul)
    {
        GameObject spawnedSoul = Instantiate(soul, transform.position, Quaternion.identity) as GameObject;
        currentSoulsAmount--;
        yield return new WaitForSeconds(5);
    }
    private GameObject PickedSoulToSpawn()
    {
        index = Random.Range(0, SoulsArray.Length);
        return SoulsArray[index];
    }

}
