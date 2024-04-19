using UnityEngine;

public class Path : MonoBehaviour
{
    public static Transform[] path;
 
    public Transform [] GetPath () 
    {
        path = new Transform[transform.childCount];
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = transform.GetChild(i);
        }

        return path;
    }
    public Transform [] GetInvertedPath ()
    {
        path = new Transform[transform.childCount];
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = transform.GetChild(path.Length - 1 -i);    
        }

        return path;
    }
}
