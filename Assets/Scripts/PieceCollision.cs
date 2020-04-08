using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCollision : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip clip;
    MeshRenderer rend;
    public Transform twoPointsText;
    public Transform particles;
    // Start is called before the first frame update
    void Start()
    {
        twoPointsText.gameObject.SetActive(false);
        particles.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            audioSrc = GetComponent<AudioSource>();
            audioSrc.clip = clip;
            audioSrc.Play();
            twoPointsText.gameObject.SetActive(true);
            particles.gameObject.SetActive(true);
            rend = GetComponent<MeshRenderer>();
            rend.enabled = false;
            ManagerScore.instance.PiecePoint();
            Destroy(gameObject, 3f);
        }
    }


}
