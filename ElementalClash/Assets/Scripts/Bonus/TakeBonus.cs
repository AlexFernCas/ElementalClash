using UnityEngine;

public class TakeBonus : MonoBehaviour
{
    private string tagName;
    public BonusManager bonusManager;
    void OnCollisionEnter(Collision collision)
    {
        tagName = collision.gameObject.tag;
        if (gameObject.tag == "threeSegBonus")
        {

            if (tagName.Contains("Left"))
            {
                bonusManager.ActiveThreeSegBonusButton();
                bonusManager.TakedBonus();
                Destroy(gameObject); 
            }
            else if (tagName.Contains("Right"))
            {
                //mlAgent.HasThreeSegBonus();
                bonusManager.TakedBonus();
                Destroy(gameObject);
            }            
        } 
        else if (gameObject.tag == "wallBonus")
        {
            if (tagName.Contains("Left"))
            {
                bonusManager.ActiveWallBonusButton();
                bonusManager.TakedBonus();
                Destroy(gameObject); 
            }
            else if (tagName.Contains("Right"))
            {
                //mlAgent.HasWallBonus();
                bonusManager.TakedBonus();
                Destroy(gameObject);
            }           
        }
        else if (gameObject.tag == "duplicateBonus")
        {
            if (tagName.Contains("Left"))
            {
                bonusManager.ActiveDuplicateBonusButton();
                bonusManager.TakedBonus();
                Destroy(gameObject); 
            }
            else if (tagName.Contains("Right"))
            {
                //mlAgent.HasDuplicateBonus();
                bonusManager.TakedBonus();
                Destroy(gameObject);
            }           
        }
    } 

    public void SetBonusManager (BonusManager bonusManager)
    {
        this.bonusManager = bonusManager;
    }
}

