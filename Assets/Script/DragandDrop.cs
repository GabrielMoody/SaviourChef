using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragandDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private int total;
    [SerializeField] private TextMeshProUGUI total_text;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition;

    private GameObject currentDropZone;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = transform.position;
        total_text.text = total.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (total <= 0)
        {
            eventData.pointerDrag = null;
            return;
        }

        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (currentDropZone != null)
        {
            DropZone dropZone = currentDropZone.GetComponent<DropZone>();
            if (dropZone != null && dropZone.customer != null)
            {
                string neededDish = dropZone.customer.GetNeededDish();
                string itemName = gameObject.name;

                if (itemName == neededDish)
                {
                    total -= 1;
                    total_text.text = total.ToString();
                    GameManager.Instance.AddScore(10);
                    GameManager.Instance.CustomerServed();

                    Destroy(dropZone.customer.gameObject);
                    ResetPosition();
                    return;
                }
                else
                {
                    total -= 1;
                    total_text.text = total.ToString();
                    GameManager.Instance.AddScore(-10);
                }
            }
        }

        ResetPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DropZone"))
        {
            currentDropZone = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DropZone"))
        {
            currentDropZone = null;
        }
    }

    public void ResetPosition()
    {
        rectTransform.position = initialPosition;
    }
}
