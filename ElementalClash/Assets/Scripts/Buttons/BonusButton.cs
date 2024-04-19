public class BonusButton : Button
{
    private float fullImage;

    void Start (){
        SetActive(false);
        fillImage.fillAmount = 100f;
        GetPower(100);
    }
    public void FillAmount(){
        fillImage.fillAmount = fullImage;
    }

    public new void SetActive (bool set){
        gameObject.SetActive(set);
    }

    public bool IsActive(){
        return gameObject.activeSelf;
    }

}
