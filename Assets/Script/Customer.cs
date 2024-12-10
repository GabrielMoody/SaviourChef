using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Customer : MonoBehaviour
{
    public Sprite[] dishSprites;
    public Image dishImage;    
    private string neededDish;
    private GameObject currentDropZone;
    public GameManager gameManager;

    public Sprite MaleSprite;
    public Sprite FemaleSprite;
    private SpriteRenderer spriteRenderer;
    private Image imageRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        imageRenderer = GetComponent<Image>();
    }
    void Start()
    {
        Randomize();
        string[] dishes = { "Bread", "Water", "Fish" };

        neededDish = dishes[Random.Range(0, dishes.Length)];
        UpdateDishImage(neededDish);
     
    }

    public void Randomize()
    {
        UnityEngine.Sprite name = Random.value > 0.5f ? MaleSprite : FemaleSprite;
        spriteRenderer.sprite = name;
        // imageRenderer.sprite = name;
    }

    void Update()
    {
    }

    public string GetNeededDish(){
        return neededDish;
    }

    private void UpdateDishImage(string dishName)
    {
        if (dishName == "Bread")
            dishImage.sprite = dishSprites[0];
        else if (dishName == "Water")
            dishImage.sprite = dishSprites[1];
        else if (dishName == "Fish")
            dishImage.sprite = dishSprites[2];

        dishImage.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BoundaryZone"))
        {
            gameManager.AddScore(-10);
            gameManager.CustomerServed();
        }
    }
}