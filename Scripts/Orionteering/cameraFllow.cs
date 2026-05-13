using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraFllow : MonoBehaviour
{
    public Transform playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos != null)
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -10);
        }
    }


    public void RestartScene()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
