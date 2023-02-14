using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    float spawnTimer = 0f;
    float spawnTimerTotal = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > spawnTimerTotal)
        {
            spawnTimer = 0;
            Instantiate(prefab, new Vector3(Random.Range(-70f, 70f), 0, Random.Range(-70f, 70f)), Quaternion.identity);
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
    }
}
