using System.Collections.Generic;
using UnityEngine;

public class particleManager : MonoBehaviour
{   

    public GameObject[] particle;
    public string[] particleNames;

    private Dictionary<string , GameObject> particles = new Dictionary<string, GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var index = 0;
        foreach (var p in particle)
        {
            particles.Add(particleNames[index], particle[index]);
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SpawnParticle(string name , Transform at)
    {
        if (particles.ContainsKey(name))
        {
            Instantiate(particles[name], at.position , Quaternion.identity);
            Debug.Log("Spawned particle");
        }
        else
        {
            Debug.Log("No such particle found");
        }
        
    }

}
