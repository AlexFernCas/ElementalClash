using UnityEngine;

public class BonusTranslation : MonoBehaviour
{
    private Pathfinder pathfinder;
    private float speed = 20f;
    private Transform target;
    private Transform [] path;
    private int pathIndex = 0;
    private PathState currentPath;
    
    private enum PathState 
    {
        LeftInvertedStart,
        LeftInvertedBottom,
        LeftInvertedTop,
        Center,
        InvertedCenter,
        RightInvertedStart,
        RightInvertedBottom,
        RightInvertedTop
    }
    
    void Awake ()
    {
        pathfinder = gameObject.AddComponent<Pathfinder>();
    }
    void Start ()
    {
        if(gameObject.tag.Contains ("Left"))
        {
            if(GameMaster.Instance.GetRightCenterDirectioner())
            {
                path = pathfinder.GetRightInvertedBottomPath();
                currentPath = PathState.RightInvertedBottom;
            } else 
            {
                path = pathfinder.GetRightInvertedTopPath();
                currentPath = PathState.RightInvertedTop;
            }
        } else 
        {
            if(GameMaster.Instance.GetLeftCenterDirectioner())
            {
                path = pathfinder.GetLeftInvertedBottomPath();
                currentPath = PathState.LeftInvertedBottom;
            } else 
            {
                path = pathfinder.GetLeftInvertedTopPath();
                currentPath = PathState.LeftInvertedTop;
            }
        }        
        target = path[pathIndex];
    }

    void Update ()
    {
        Translate();
    }
    void Translate ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);
        
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }
    
    void GetNextWayPoint ()
    {        
        if (pathIndex + 1 < path.Length)
        {
            pathIndex++;  
            target = path[pathIndex];
        }
        else
        {   
           Path();
        }
    }

    void Path()
    {
        ResetIndex();
        switch (currentPath)
        {
                case PathState.RightInvertedTop:
                case PathState.RightInvertedBottom:
                    path = pathfinder.GetRightInvertedStartPath();
                    currentPath = PathState.RightInvertedStart;
                    break;

                case PathState.RightInvertedStart:
                    Destroy(gameObject);
                    return;

                case PathState.LeftInvertedBottom:
                case PathState.LeftInvertedTop:
                    path = pathfinder.GetLeftInvertedStartPath();
                    currentPath = PathState.LeftInvertedStart;
                    break;

                case PathState.LeftInvertedStart:
                    Destroy(gameObject);
                    return;
            }           
        target = path[pathIndex];            
    }

    void ResetIndex(){
        pathIndex = 0;
    }
}
