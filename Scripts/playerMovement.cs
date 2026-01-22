using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speedMult;
    private CharacterController playerControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerControl.Move(transform.up * speedMult * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)) 
        {
            playerControl.Move(-transform.up * speedMult * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            playerControl.Move(-transform.right * speedMult * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            playerControl.Move(transform.right * speedMult * Time.deltaTime);
        }
    }
}
