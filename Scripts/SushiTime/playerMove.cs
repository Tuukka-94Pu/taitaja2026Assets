using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    private CharacterController plaerMovr;
    private InputAction MOVE;

    public float speedMult;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plaerMovr = GetComponent<CharacterController>();
        MOVE = InputSystem.actions.FindAction("move");
        speedMult = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(MOVE.IsPressed())
        {
            var mover = MOVE.ReadValue<Vector2>();
            Vector3 actulaMove = new Vector3(mover.x, 0 , mover.y);
            plaerMovr.Move(actulaMove * speedMult * Time.deltaTime);
        }
    }
}
