using UnityEngine;
using UnityEngine.UI;

public class CardCreator : MonoBehaviour
{
    public Sprite cardImage;

    void Start()
    {
        GameObject card = new GameObject("Card");
        card.AddComponent<RectTransform>();
        card.AddComponent<CanvasRenderer>();
        Image image = card.AddComponent<Image>();

        image.sprite = cardImage;

        RectTransform rectTransform = card.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(200, 300);
        rectTransform.localPosition = new Vector3(2, -2, 12);

        card.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }
}
