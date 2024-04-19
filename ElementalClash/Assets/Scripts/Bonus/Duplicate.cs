using System.Collections;
using UnityEngine;

public class Duplicate : MonoBehaviour
{
    bool nextDuplicate;
    string tagName;
    float destroyTimer;

    public BonusTranslation fireUnit;
    public BonusTranslation waterUnit;
    public BonusTranslation windUnit;
    public BonusTranslation earthUnit;

    void Start()
    {
        SetActive(false);
        tagName = gameObject.tag;
        destroyTimer = 3f;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (tagName == "duplicateRight" && nextDuplicate)
        {
            if (collision.gameObject.CompareTag("Fire_Left"))
            {
                Instantiate(fireUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Water_Left"))
            {
                Instantiate(waterUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Wind_Left"))
            {
                Instantiate(windUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Earth_Left"))
            {
                Instantiate(earthUnit, transform.position, transform.rotation);            
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
