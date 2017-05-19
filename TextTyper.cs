using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTyper : MonoBehaviour
{

    public float letterPause = 0.2f;
    public AudioClip typeSound1;
    public AudioClip typeSound2;
    public bool CR_isRunning = false;
    public string message;
    public int timeInSeconds = 7;
    Text textComp;

    // Use this for initialization
    void Start()
    {
        textComp = this.GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        startTextCoroutine(timeInSeconds);
    }

    private void Update()
    {
        if (CR_isRunning == false)
        {
            textComp.text = "";
        }
    }
    IEnumerator TypeText(int seconds)
    {
        CR_isRunning = true;
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            if (typeSound1 && typeSound2)
                SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        yield return new WaitForSeconds(seconds);
        CR_isRunning = false;
    }
    public void startTextCoroutine(int seconds)
    {
        StartCoroutine(TypeText(seconds));
    }
}