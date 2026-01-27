using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(player.transform.hasChanged)
        {
            transform.localPosition = Random.insideUnitSphere * 0.02f;
            player.transform.hasChanged = false;
        }       
       
    }
}
