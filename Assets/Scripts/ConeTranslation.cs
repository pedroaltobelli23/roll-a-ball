using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeTranslation : MonoBehaviour
{
    public float speed;
    public float min; // Minimum X coordinate
    public float max; // Maximum X coordinate
    public int eixo;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movementX = new Vector3 (0.03f, 0.0f, 0.0f);
        Vector3 movementZ = new Vector3 (0.0f, 0.0f, 0.03f);

        if(eixo==0){
            if(transform.position.x < min)
            {
                movementX*=1;
            }
            if(transform.position.x > max)
            {
                movementX*=-1;
            }
            rb.AddForce (movementX * speed);
        }else{
            if(transform.position.z < min)
            {
                movementZ*=1;
            }
            if(transform.position.z > max)
            {
                movementZ*=-1;
            }
            rb.AddForce (movementZ * speed); 
        }
    
    }
}