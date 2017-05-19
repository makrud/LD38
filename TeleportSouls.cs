using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSouls : MonoBehaviour
{
    TreeHealth th;
    AudioSource audio;

    SoulController sc;

    public AudioClip enemyInPortal;
    public AudioClip friendInPortal;
    private void Awake()
    {
        th = GameObject.FindGameObjectWithTag("Tree").GetComponent<TreeHealth>();
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            sc = collision.gameObject.GetComponent<SoulController>();
            audio.clip = enemyInPortal;
            audio.Play();
            th.TreeTakeDamage(sc.enemyDmgToTree);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Friendly"))
        {
            audio.clip = friendInPortal;
            audio.Play();
            Destroy(collision.gameObject);
        }
    }
}
