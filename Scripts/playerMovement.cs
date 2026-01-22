using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speedMult;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.up * speedMult * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)) 
        {
            transform.Translate(-transform.up * speedMult * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * speedMult * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
           transform.Translate(transform.right * speedMult * Time.deltaTime);
        }
    }
}
