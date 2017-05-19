using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeHealth : MonoBehaviour
{
    private GameObject TreeHealthBar;

    public float startingHealth = 180;
    public float currentHealth;
    Image healthImage;
    RectTransform rt;
    public bool isDead = false;
    Color startingColor;
    // Use this for initialization
    void Start()
    {
        TreeHealthBar = GameObject.FindGameObjectWithTag("TreeHealthBar");
        healthImage = TreeHealthBar.GetComponent<Image>();
        rt = TreeHealthBar.GetComponent<RectTransform>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == startingHealth)
        {
            healthImage.color = Color.green;
        }
        if (currentHealth < startingHealth / 2)
        {
            healthImage.color = new Color(253, 183, 0);
        }
        if (currentHealth < startingHealth / 4)
        {
            healthImage.color = Color.red;
        }
    }
    public void TreeTakeDamage(int amount)
    {
        // Reduce the current health by the damage amount.
        currentHealth -= amount;
        rt.sizeDelta = new Vector2(currentHealth, 8);
        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            //Death();
        }
    }
}
