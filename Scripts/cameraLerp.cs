using UnityEngine;

public class cameraLerp : MonoBehaviour
{
    public GameObject playerRoot;
    public float cammovespeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(transform.position.x, transform.position.y, -10); // ensures that transform.position.z remains at -10
        transform.position = Vector3.Lerp(transform.position, playerRoot.transform.position, cammovespeed * Time.deltaTime);
       

    }
}
