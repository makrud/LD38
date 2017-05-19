using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    PlayerController pc;

    Camera cam;
    bool followPlayer = true;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        pc = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            followPlayer = false;
            pc.setMoving(false);
        }
        else
        {
            followPlayer = true;
        }
        if (followPlayer == true)
        {
            cameraFollowPlayer();
        }
        else
        {
            lookAHead();
        }
    }

    void setFollowPlayer(bool val)
    {
        followPlayer = val;
    }

    void cameraFollowPlayer()
    {
        Vector3 newPos = new Vector3(Player.transform.position.x, Player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }
    void lookAHead()
    {
        Vector3 camPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        camPos.z = -10;
        Vector3 direction = camPos - this.transform.position;
        if (Player.GetComponent<SpriteRenderer>().isVisible == true)
        {
            transform.Translate(direction * 2 * Time.deltaTime);
        }
    }
}
