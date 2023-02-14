using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alligator : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nav;

    bool wandering = true;
    float moveTimer = 0;
    float moveTimerTotal = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerAnchor");
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 25)
        {
            nav.SetDestination(player.transform.position);
            nav.speed = 4f;
            wandering = false;
        }
        else
        {
            if(!wandering) wandering = true;
        }

        FaceDirection();

        if(wandering)
        {
            if(moveTimer > moveTimerTotal)
            {
                moveTimer = 0;
                nav.SetDestination(transform.position + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)));
                nav.speed = 3f;
            }
            else
            {
                moveTimer += Time.deltaTime;
            }
        }

        if(Vector3.Distance(transform.position, player.transform.position) > 85)
        {
            Destroy(this.gameObject);
        }
    }

    private void FaceDirection()
    {
        if (nav.desiredVelocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (nav.desiredVelocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
