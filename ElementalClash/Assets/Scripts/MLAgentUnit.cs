using UnityEngine;

public class MLAgentUnit : MonoBehaviour
{

        void Start()
    {
        if (gameObject.CompareTag("Fire_Right"))
        {
            transform.rotation = Quaternion.Euler(280f, 80f, 180f);
        }
        else if (gameObject.CompareTag("Water_Right"))
        {
            transform.rotation = Quaternion.Euler(280f, 90f, 180f);
        }
        else if (gameObject.CompareTag("Wind_Right"))
        {
            transform.rotation = Quaternion.Euler(280f, 90f, 180f);
        }
        else if (gameObject.CompareTag("Earth_Right"))
        {
            transform.rotation = Quaternion.Euler(280f, 90f, 180f);
        }
    }
}
