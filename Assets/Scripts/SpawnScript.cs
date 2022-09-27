using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] balloons;

    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("Hello");
        StartCoroutine(startSpawn());
    }

    public IEnumerator startSpawn()
    {
        yield return new WaitForSeconds(4);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(balloons[i], spawnPoints[i].position, Quaternion.identity);
        }
        //StartCoroutine(startSpawn());
    }
}