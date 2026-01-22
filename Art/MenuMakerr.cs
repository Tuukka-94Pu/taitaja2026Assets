using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MenuMakerr : MonoBehaviour
{
    public GameObject BackgroundImage, TextBackgroundImg, logoImg, gameName, Canvas;
    Canvas theCanvas;
    public Text gameNameText;
    RectTransform RectTransform;
    Image bgImage;
    public Sprite bgImgSprite;

    private void Awake()
    {
        Canvas = new GameObject();
        Canvas.AddComponent<Canvas>();

        theCanvas = Canvas.GetComponent<Canvas>();
        theCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        Canvas.AddComponent<CanvasScaler>();
        Canvas.AddComponent<GraphicRaycaster>();

        gameName = new GameObject();
        gameName.transform.parent = Canvas.transform;

        gameNameText = gameName.AddComponent<Text>();

        RectTransform = gameNameText.GetComponent<RectTransform>();
        RectTransform.localPosition = new Vector3(0, 0, 0);
        RectTransform.sizeDelta = new Vector3(400, 200);

        BackgroundImage = new GameObject();
        BackgroundImage.AddComponent<Image>();
        bgImage = BackgroundImage.GetComponent<Image>();
        bgImage.sprite = bgImgSprite;

    }
}
