using UnityEngine;

public class PlayerUnit : MonoBehaviour
{

    void Start()
    {
        if (gameObject.CompareTag("Fire_Left"))
        {
            transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        }
        else if (gameObject.CompareTag("Water_Left"))
        {
            transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        }
        else if (gameObject.CompareTag("Wind_Left"))
        {
            transform.rotation = Quaternion.Euler(90f, 80f, 0f);
        }
        else if (gameObject.CompareTag("Earth_Left"))
        {
            transform.rotation = Quaternion.Euler(90f, 80f, 0f);
        }
    }
   /* void Start()
    {
        gameObject.tag = tagName;
        switch(tagName)
        {
            case ("Fire_Left"):
                element = GameMaster.Element.Fire;
                break;

            case ("Water_Left"):
                element = GameMaster.Element.Water;
                break;

            case ("Wind_Left"):
                element = GameMaster.Element.Wind;
                break;

            case ("Earth_Left"):
                element = GameMaster.Element.Earth;
                break;
        }
    }

    public GameMaster.Element GetElement()
    {
        return element;
    }*/
}
