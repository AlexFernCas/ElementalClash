using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Sprite normalSprite; 
    public Sprite highlightedSprite;
    public Image fillImage;
    public Button button;
    public Player user;
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
        if (gameObject.CompareTag("Fire")){
            power = user.GetFirePower();
        } 
        else if (gameObject.CompareTag("Water"))
        {
            power = user.GetWaterPower();
        }
        else if (gameObject.CompareTag("Wind"))
        {
            power = user.GetWindPower();
        } 
        else if (gameObject.CompareTag("Earth"))
        {
            power = user.GetEarthPower();
        }

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


    public void SetFillAmount(float fillAmount){
        fillImage.fillAmount = fillAmount;
    }

    public void SetActive(bool set){
        gameObject.SetActive(set);
    }

}