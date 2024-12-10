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

    public Sprite[] orangSprite;
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
        string[] dishes = { "Bread", "Water", "Fish", "Meat", "Vegetable" };

        neededDish = dishes[Random.Range(0, dishes.Length)];
        UpdateDishImage(neededDish);
     
    }

    public void Randomize()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, 2);
        spriteRenderer.sprite = orangSprite[randomNumber];
    }

    void Update()
    {
    }

    public string GetNeededDish(){
        return neededDish;
    }

    private void UpdateDishImage(string dishName)
    {
        if(dishSprites.Length == 3 ) {
            if (dishName == "Bread")
            dishImage.sprite = dishSprites[0];
            else if (dishName == "Water")
                dishImage.sprite = dishSprites[1];
            else if (dishName == "Fish")
                dishImage.sprite = dishSprites[2];
        } else {
            if (dishName == "Bread")
                dishImage.sprite = dishSprites[0];
            else if (dishName == "Water")
                dishImage.sprite = dishSprites[1];
            else if (dishName == "Fish")
                dishImage.sprite = dishSprites[2];
            else if (dishName == "Meat")
                dishImage.sprite = dishSprites[3];
            else if (dishName == "Vegetable")
                dishImage.sprite = dishSprites[4];
        }
        
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