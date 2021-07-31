using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 11f;
    private Vector3 target;
    private float objectRadius = 0.5f;
    private bool isMoving = false;

    public Camera mainCamera;
    public Animation anim;

    // Update is called once per frame
    void Start()
    {
        anim.GetComponent<Animation>();
        mainCamera = Camera.main;
    }

        void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTarget();
        }
        if (isMoving)
        {
            Move();
        }
    }
    void SetTarget()
    {
        target = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y - objectRadius));
        isMoving = true;
    }
    void Move()
    {
        anim.Play("run");
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            isMoving = false;
            anim.Play("walk");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy collision");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
