using System.Collections;
using UnityEngine;

public class Duplicate : MonoBehaviour
{
    bool nextDuplicate;
    string tagName;
    float destroyTimer;

    public BonusTranslation userFireUnit;
    public BonusTranslation userWaterUnit;
    public BonusTranslation userWindUnit;
    public BonusTranslation userEarthUnit;

    void Start()
    {
        SetActive(false);
        tagName = gameObject.tag;
        destroyTimer = 3f;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (tagName == "duplicateR" && nextDuplicate)
        {
            if (collision.gameObject.CompareTag("Fire_Left"))
            {
                Instantiate(userFireUnit, transform.position, transform.rotation);          
            }
            else if (collision.gameObject.CompareTag("Water_Left"))
            {
                Instantiate(userWaterUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Wind_Left"))
            {
                Instantiate(userWindUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Earth_Left"))
            {
                Instantiate(userEarthUnit, transform.position, transform.rotation);            
            }
        }
        nextDuplicate = !nextDuplicate;
    }

    public void SetActive(bool set)
    {
        gameObject.SetActive(set);
        DestroyTimer();
        nextDuplicate = true;
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }
}
