using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public GameObject bullet; //assing the prefab to be spawned
    public GameObject bulletSpawnPoint; //assing an empty gameobject

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);   
            //Instantiates a bullet prefab at BulletSpawnPoints transform position
        }
    }
}
