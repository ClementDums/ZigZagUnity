using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    float initialY;
    public AudioSource audioSrc;
    public AudioClip fall;
    // Start is called before the first frame update
    void Start()
    {
       initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Loose();
    }
    void Loose()
    {
        if (transform.position.y < initialY - 1 && ManagerGame.instance.IsPlaying==true)
        {
            audioSrc.clip = fall;
            audioSrc.Play();
            GetComponent<Movement>().Fallen = true;
            ManagerGame.instance.IsPlaying = false;

        }


    }
}
