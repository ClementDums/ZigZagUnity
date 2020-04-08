using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Hitbox")
        {
            GenerateTiles.instance.GenerateMyTile();
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            Destroy(gameObject,3);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
