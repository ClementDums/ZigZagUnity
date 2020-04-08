using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float moveSpeed;
    bool isLeft = false;
    public AudioSource audioSrc;
    public AudioClip turn;
    private bool fallen;

    public bool Fallen { get => fallen; set => fallen = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        moveSpeed = speed + (float)ManagerScore.instance.ScoreInt / 20f;
        if (!fallen)
        {
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.Self);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown("space"))
        {
            ChangeDirection();
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ChangeDirection();
            }
        }
    }

    void ChangeDirection()
    {
        audioSrc.clip = turn;
        audioSrc.Play();
        if (!isLeft)
        {
            transform.Rotate(0, -45, 0);
            isLeft = true;
            return;
        }
        transform.Rotate(0, 45, 0);
        isLeft = false;

    }
}
