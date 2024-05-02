using UnityEngine;

public class RotateObject : MonoBehaviour
{   
    public float rotationSpeedZ = 0f;
    public float rotationSpeedX = 0f;
    public float rotationSpeedY = 0f;
    void Start()
    {
        if (gameObject.CompareTag("duplicateBonus"))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90f);
            rotationSpeedZ = 30f;
        } 
        if (gameObject.CompareTag("wallBonus"))
        {
            gameObject.transform.position += new Vector3 (0, 0, -2);
            rotationSpeedX = 30f;
        }
    }

    void Update()
    {
        if (gameObject.CompareTag("duplicateBonus"))
        {
            Vector3 rotationVectorZ = new Vector3(0f, 0f, rotationSpeedZ * Time.deltaTime);
            transform.Rotate(rotationVectorZ, Space.Self);
        } 
        else if (gameObject.CompareTag("wallBonus"))
        {
            Vector3 rotationVectorZ = new Vector3(rotationSpeedX * Time.deltaTime, 0f, 0f);
            transform.Rotate(rotationVectorZ, Space.Self);
        }
    }
}