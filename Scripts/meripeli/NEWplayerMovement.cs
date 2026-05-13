using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NEWplayerMovement : MonoBehaviour
{

    private InputAction move;
    private Rigidbody2D playerRB;

    public GameObject spotligthRoot;
    public GameObject playerSprite;
    public GameObject SlowdownEffect;

    private int moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = InputSystem.actions.FindAction("move");
        playerRB = GetComponent<Rigidbody2D>();
        moveSpeed = 20;
        SlowdownEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(move.IsPressed())
        {
            AudioManager.instance.PlaySound("move");
            Vector2 movedir = move.ReadValue<Vector2>();
            playerRB.AddForce(movedir * moveSpeed * Time.deltaTime);

            if (movedir.y > 0)
            {
                spotligthRoot.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (movedir.y < 0)
            {
                spotligthRoot.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            if (movedir.x > 0)
            {
                spotligthRoot.transform.rotation = Quaternion.Euler(0, 0, 0);
                playerSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (movedir.x < 0)
            {
                spotligthRoot.transform.rotation =  Quaternion.Euler(0, 0, 180);
                playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void SlowedDown()
    {
        moveSpeed = 1;
        SlowdownEffect.SetActive(true);
        StartCoroutine(slowCooldown());
    }
    private IEnumerator slowCooldown()
    {
        yield return new WaitForSeconds(3);
        SlowdownEffect.SetActive(false);
        moveSpeed = 20;
    }
}
