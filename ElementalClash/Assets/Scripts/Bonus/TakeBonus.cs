using UnityEngine;

public class TakeBonus : MonoBehaviour
{
    private string tagName;

    void OnCollisionEnter(Collision collision)
    {
        tagName = collision.gameObject.tag;
        if (gameObject.tag == "threeSegBonus")
        {

            if (tagName.Contains("Left"))
            {
                Player.Instance.ActiveThreeSegBonusButton();
                GameMaster.Instance.TakedBonus();
                Destroy(gameObject); 
            }
            else if (tagName.Contains("Right"))
            {
                GameMaster.Instance.TakedBonus();
                Destroy(gameObject);
            }            
        } 
        else if (gameObject.tag == "wallBonus")
        {
            if (tagName.Contains("Left"))
            {
                Player.Instance.ActiveWallBonusButton();
                GameMaster.Instance.TakedBonus();
                Destroy(gameObject); 
            }
            else if (tagName.Contains("Right"))
            {
                GameMaster.Instance.TakedBonus();
                Destroy(gameObject);
            }           
        }
        else if (gameObject.tag == "duplicateBonus")
        {
            if (tagName.Contains("Left"))
            {
                Player.Instance.ActiveDuplicateBonusButton();
                GameMaster.Instance.TakedBonus();
                Destroy(gameObject); 
            }
            else if (tagName.Contains("Right"))
            {
                GameMaster.Instance.TakedBonus();
                Destroy(gameObject);
            }           
        }
    } 
}

