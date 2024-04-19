using UnityEngine;

public class MLAgentUnit : MonoBehaviour
{
    GameMaster.Element element;
    string tagName;
    public Vector3 position;
    public Quaternion rotation;
    /*void Start()
    {
        gameObject.tag = tagName;
        switch(tagName)
        {
            case ("Fire_Right"):
                element = GameMaster.Element.Fire;
                break;

            case ("Water_Right"):
                element = GameMaster.Element.Water;
                break;

            case ("Wind_Right"):
                element = GameMaster.Element.Wind;
                break;

            case ("Earth_Right"):
                element = GameMaster.Element.Earth;
                break;
        }
    }

    public GameMaster.Element GetElement()
    {
        return element;
    }*/
}
