using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {
    public float timeLeft = 5* 60.0f;
    public Text estimatedTime;

    // Use this for initialization
    void Start () {
        estimatedTime.text = timeLeft.ToString();
	}
    // Update is called once per frame

    void Update()
    {
        timeLeft -= Time.deltaTime;
        estimatedTime.text = timeLeft.ToString().Split('.')[0];
    }
}
