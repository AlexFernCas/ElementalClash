using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    GameMaster.Element element;
    string tagName;
    public Vector3 position;
    public Quaternion rotation;
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
