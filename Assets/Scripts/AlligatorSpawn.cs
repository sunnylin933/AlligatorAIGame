using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlligatorSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    GameObject player;
    GameObject[] alligators;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        player = GameObject.Find("PlayerAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        alligators = GameObject.FindGameObjectsWithTag("Alligator");
        if (alligators.Length < 14)
        {
            float xOffset = RandomClampedValue();
            float zOffset = RandomClampedValue();

            Instantiate(prefab, new Vector3(player.transform.position.x + xOffset, player.transform.position.y, player.transform.position.z + zOffset), Quaternion.identity);
        }
    }

    float RandomClampedValue()
    {
        float value = Random.Range(25, 70);
        float sign = Random.value < 0.5f ? -1f : 1f;
        return value * sign;
    }
}
