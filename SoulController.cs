using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : MonoBehaviour
{
    public GameObject Player;
    private PlayerController pc;
    public int soulSpeed;
    public GameObject TargetPortal;
    Rigidbody2D rb;
    private bool damaged = false;
    private bool isDead = false;
    public int enemyDmgToTree = 10;


    public int startingHealth = 40;
    public int currentHealth;
    public AudioSource audio;
    public AudioClip DeathSound;
    public AudioClip DeathSound2;

    private GameManager gm;
    Animator anim;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;
    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        string[] splittedItemName = gameObject.name.Split('(');
        gameObject.name = splittedItemName[0];
        Player = GameObject.FindGameObjectWithTag("Player");
        pc = Player.GetComponent<PlayerController>();
        TargetPortal = GameObject.FindGameObjectWithTag("Portal");
        if (gameObject.name == "BigEvilSoul")
        {
            soulSpeed = 1;
        }
        else soulSpeed = Random.Range(1, 4);
        audio = gameObject.GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPortal();
        //RotateToPortal();
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

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Play the hurt sound effect.
        audio.Play();
        print("Health LEFT: " + currentHealth);
        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            //StartCoroutine(DeathSounds());
            Death();
        }
    }
    void Death()
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        isDead = true;
        anim.SetBool("isDead", true);
        if (gameObject.name == "BigEvilSoul") { gm.score += 100f; } else gm.score += 20f;
        audio.clip = DeathSound;
        audio.pitch = randomPitch;
        audio.Play();
        Destroy(this.gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }
    //IEnumerator DeathSounds()
    //{
    //    if (DeathSound && DeathSound2)
    //        SoundManager.instance.RandomizeSfx(DeathSound, DeathSound2);
    //    yield return 0;
    //}
}
