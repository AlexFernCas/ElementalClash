using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Sprite normalSprite; 
    public Sprite highlightedSprite;
    public Image fillImage;
    public Button button;
    private bool selected;
    private float power;
    private float maxPower;
    void Start()
    {
        maxPower = 100;
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
        SetFillAmount(power/maxPower);
    }

    public void Select()
    {
        selected = true;
        if (button!=null) button.Select();
    }

    public void Unselect()
    {
        selected = false;
        if (button!=null) button.Unselect();
    }

    public void GetPower(int power){
        this.power = (float)power;
    }

    public void SetFillAmount(float fillAmount){
        fillImage.fillAmount = fillAmount;
    }

    public void SetActive(bool set){
        gameObject.SetActive(set);
    }

}