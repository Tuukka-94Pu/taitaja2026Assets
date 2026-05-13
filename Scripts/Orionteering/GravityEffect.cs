using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GravityEffect : MonoBehaviour
{
    public Transform orbitParent;
    public Transform earthCenter;
    public Transform moonCenter;

   // public GameObject indicatorArrow;

    private Rigidbody2D playerRigid;

    private float maxVelocity;
    private float gravValue;
    private float gravityThreshold;

    public TMP_Text verticalVel;
    public TMP_Text horizontalVel;

    private InputAction move;
    public InputAction rotate;

    private AudioManager audios;

    private bool motorsPlaying;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        audios = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
        motorsPlaying = false;
        gravValue = 0.4f;
        move = InputSystem.actions.FindAction("move");
        rotate.Enable();
        maxVelocity = 3f;
        gravityThreshold = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToEarth = Vector2.Distance(transform.position, earthCenter.position);
        float distanceToMoon = Vector2.Distance(transform.position, moonCenter.position);

        if(move.IsPressed())
        {
            var moves = move.ReadValue<Vector2>();  

            playerRigid.AddForce(moves * Time.deltaTime, ForceMode2D.Impulse);
            GetComponent<fuelLogic>().UseFuel();
            if(motorsPlaying == false)
            {
                motorsPlaying = true;
                audios.playSound("motors");
                anim.SetBool("moving", true);
                StartCoroutine(noSoundSpam());
            }
            if (GetComponent<tutorialMode>().tutStage1 == false)
            {
                GetComponent<tutorialMode>().inputRead();
            }
        }
        if(move.WasReleasedThisFrame())
        {
            audios.stopSound();
            motorsPlaying = false;
            anim.SetBool("moving", false);
        }


        if(rotate.IsPressed())
        {
            var rotations = rotate.ReadValue<float>();
            transform.Rotate(0,0,rotations * 0.5f);
            if (GetComponent<tutorialMode>().tutStage1 == false)
            {
                GetComponent<tutorialMode>().inputRead();
            }
        }

        float velocity = (float)playerRigid.linearVelocity.magnitude;

        if (playerRigid.linearVelocityY < maxVelocity && playerRigid.linearVelocityX < maxVelocity)
        {

            if (distanceToEarth < 50f && distanceToMoon > 25f)
            {
                orbitParent = earthCenter;
            }
            if (distanceToMoon < 25f)
            {
                orbitParent = moonCenter;
            }
            if(distanceToEarth > 50f && distanceToMoon > 25f)
            {
                orbitParent = null;
            }

            transform.parent = orbitParent;
        }

        if (orbitParent != null && (velocity < gravityThreshold || velocity > -gravityThreshold))
        {
            transform.position = Vector2.MoveTowards(transform.position, orbitParent.position, gravValue * Time.deltaTime);
            
        }
       

        if ((playerRigid.linearVelocityX > maxVelocity || playerRigid.linearVelocityY > maxVelocity) && (distanceToEarth > 80f || distanceToMoon > 50f))
        {
            transform.parent = null;
        }
        

        earthCenter.transform.Rotate(0,0,3 * Time.deltaTime);
        moonCenter.transform.Rotate(0, 0, 1 * Time.deltaTime);

        float fakeX = playerRigid.linearVelocityX * 100;
        float fakeY = playerRigid.linearVelocityY * 100;

        verticalVel.text = "Vertical\nVelocity:\n" + fakeX.ToString("F0");
        horizontalVel.text ="Horizontal\nVelocity:\n" +fakeY.ToString("F0");
        
    }

    private IEnumerator noSoundSpam()
    {
        yield return new WaitForSeconds(1.5F);
        motorsPlaying = false;
    }
}
