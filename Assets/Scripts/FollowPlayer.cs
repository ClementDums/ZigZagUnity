using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float distanceX;
    public float distanceZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(target.position.x+distanceX, transform.position.y, target.position.z - distanceZ);

        //transform.Translate(target.position.z, transform.position.y, target.position.z,Space.World);
    }
}
