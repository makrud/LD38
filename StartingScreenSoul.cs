using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScreenSoul : MonoBehaviour {
    public int soulSpeed;
    public GameObject TargetPortal;
    Rigidbody2D rb;

    public AudioSource audio;
    public AudioClip DeathSound;
    public AudioClip DeathSound2;

    private GameManager gm;
    // Use this for initialization
    void Start()
    {
        string[] splittedItemName = gameObject.name.Split('(');
        gameObject.name = splittedItemName[0];
        TargetPortal = GameObject.FindGameObjectWithTag("Portal");
        soulSpeed = Random.Range(1, 4);
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPortal();
        RotateToPortal();
    }

    void MoveToPortal()
    {
        float step = soulSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, TargetPortal.transform.position, step);
    }
    void RotateToPortal()
    {
        Vector2 dir = TargetPortal.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, soulSpeed * Time.deltaTime);
    }
}
