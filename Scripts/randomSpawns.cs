using System.Collections;
using UnityEngine;

public class randomSpawns : MonoBehaviour
{
    public GameObject spawnable;
    public Transform[] spawnPoints;

    private bool spawnPrevention;
    public int minimumWait;
    public int maximumWait;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(spawnPrevention == false)
        {
            var i = Random.Range(0, spawnPoints.Length);
            spawnPrevention = true;
            Instantiate(spawnable, spawnPoints[i].position , Quaternion.identity);

            StartCoroutine(WAITbeforeSpawn());
        }

    }
    private IEnumerator WAITbeforeSpawn()
    {
        yield return new WaitForSeconds(Random.Range(minimumWait, maximumWait));
        spawnPrevention = false;
    }
}
