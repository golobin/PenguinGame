using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 1500f;
    private Rigidbody rb;
    private float zDestroy = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (transform.position.z < zDestroy)
        {
            DestroyObj();
        }
    }

    void Move()
    {
        //transform.LookAt(target);
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        rb.AddForce(Vector3.forward * -speed * Time.deltaTime);
    }
    void DestroyObj() 
    {
        Destroy(gameObject);
    }
}
