using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class buttonAnim : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{
    //Add to a Button to animate it being highlighted


    float scaleFun = 1.0f;

    void Update()
    {
        this.transform.localScale = new Vector3(scaleFun, scaleFun);
    }
    public void OnPointerEnter(PointerEventData idk)
    {
        StartCoroutine(UpscaleWait());
    }

    public void OnPointerExit(PointerEventData idk)
    {
        StartCoroutine(DownscaleWait());
    }
    private IEnumerator DownscaleWait()
    {
        yield return new WaitForSeconds(0.05f);
        scaleFun -= 0.1f;
        yield return new WaitForSeconds(0.05f);
        scaleFun -= 0.1f;
    }
    private IEnumerator UpscaleWait()
    {
        yield return new WaitForSeconds(0.05f);
        scaleFun += 0.1f;
        yield return new WaitForSeconds(0.05f);
        scaleFun += 0.1f;
    }
}
