using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    private SpriteRenderer renderer;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.GetGameStatus()) 
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * playerSpeed * Time.deltaTime;
                renderer.flipX = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * playerSpeed * Time.deltaTime;
                renderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.back * playerSpeed * Time.deltaTime;
            }
        }
        else
        {
            if(rb.detectCollisions) rb.detectCollisions = false;
            if(renderer.enabled) renderer.enabled = false;
        }
    }
}
