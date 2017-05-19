using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScythe : MonoBehaviour {
    PlayerController pc;

    SoulController sc;

    int damage = 20;
	// Use this for initialization
	void Start () {
        pc = gameObject.GetComponentInParent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && pc.isAttacking)
        {
            sc = collision.gameObject.GetComponent<SoulController>();
            sc.TakeDamage(damage);
        }
    }
}
