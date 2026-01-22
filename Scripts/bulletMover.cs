using UnityEngine;

public class bulletMover : MonoBehaviour
{
    public float bulletSpeedMult;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * bulletSpeedMult * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
