using UnityEngine;
using UnityEngine.UI;

public class Directioner : MonoBehaviour
{
    public Sprite normalSprite; 
    public Sprite highlightedSprite;
    public Image fillImage;
    private bool selected;
    
    void Start()
    {
        selected = false;
    }

    void Update()
    {
        if (selected)
        {
            fillImage.sprite = highlightedSprite;
        } else 
        {
            fillImage.sprite = normalSprite;
        }

    }
    public void OnClickDirectioner()
    {
        selected = !selected;
    }
}