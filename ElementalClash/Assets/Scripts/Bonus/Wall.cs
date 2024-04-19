using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public float duration; 

    void Start (){
        duration = 3;
        SetActive(false);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "playerWall")
        {
            if(collision.gameObject.tag.Contains("Right"))
            {
                Destroy(collision.gameObject);
            }
        }
        else if (gameObject.tag == "mlAgentWall")
        {
            if(collision.gameObject.tag.Contains("Left"))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public void SetActive (bool set)
    {
        gameObject.SetActive(set);
        if (set==true) StartCoroutine(Descative());
    }

    IEnumerator Descative(){
        yield return new WaitForSeconds(duration);
        SetActive(false);

    }
}
