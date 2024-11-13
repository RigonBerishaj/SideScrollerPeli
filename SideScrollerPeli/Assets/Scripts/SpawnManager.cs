using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0); // Kordinaatit, johon esteet ilmestyv‰t.
    private float startDelay = 2; // T‰m‰ funktio tekee sen ett‰ kun aloittaa pelin niin ensimm‰inen este ilmestyy kahden sekunnin kuluttua.
    private float repeatRate = 2; // T‰m‰ on viive uusien esteiden syntymiseen (sekunteina)
    private PlayerController playerControllerScript; // Viittaus PlayerController scriptiin

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // K‰ynnist‰‰ SpawnObstacle-metodin toistuvasti tietyin aikav‰lein
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}