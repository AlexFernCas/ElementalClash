using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 60f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto alrededor de su propio eje en el eje Y (puedes cambiar el eje según lo necesites)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}