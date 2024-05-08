using UnityEngine;
using UnityEngine.UI;

public class BonusButton : MonoBehaviour
{
    public Image fillImage;
    private float fullImage;

    void Start (){
        SetActive(false);
        fillImage.fillAmount = 100f;
    }
    public void FillAmount(){
        fillImage.fillAmount = fullImage;
    }

    public void SetActive (bool set){
        gameObject.SetActive(set);
    }

    public bool IsActive(){
        return gameObject.activeSelf;
    }

}
