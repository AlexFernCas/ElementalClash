using UnityEngine;

public class Translation : MonoBehaviour
{
    private Pathfinder pathfinder;
    private float speed = 20f;
    private Transform target;
    private Transform [] path;
    private int pathIndex = 0;
    private PathState currentPath;
    
    private enum PathState 
    {
        LeftStart,
        LeftInvertedStart,
        LeftBottom,
        LeftInvertedBottom,
        LeftTop,
        LeftInvertedTop,
        Center,
        InvertedCenter,
        RightStart,
        RightInvertedStart,
        RightBottom,
        RightInvertedBottom,
        RightTop,
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
            path = pathfinder.GetLeftStartPath();
            currentPath = PathState.LeftStart;
        } else 
        {
            path = pathfinder.GetRightStartPath();
            currentPath = PathState.RightStart;
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
        
        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
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
                case PathState.LeftStart:
                    if (GameMaster.Instance.GetLeftDirectioner())
                    {
                        path = pathfinder.GetLeftBottomPath();
                        currentPath = PathState.LeftBottom;
                    } else 
                    {
                        path = pathfinder.GetLeftTopPath();
                        currentPath = PathState.LeftTop;
                    }
                    break;

                case PathState.LeftBottom:
                    if(GameMaster.Instance.GetLeftBottomDirectioner())
                    {
                        path = pathfinder.GetInvertedCenterPath();
                        currentPath = PathState.InvertedCenter;
                    } else 
                    {
                        path = pathfinder.GetRightInvertedBottomPath();
                        currentPath = PathState.RightInvertedBottom;
                    }
                    break;
                
                case PathState.LeftTop:
                    if(GameMaster.Instance.GetLeftTopDirectioner())
                    {
                        path = pathfinder.GetInvertedCenterPath();
                        currentPath = PathState.InvertedCenter;
                    } else 
                    {
                        path = pathfinder.GetRightInvertedTopPath();
                        currentPath = PathState.RightInvertedTop;
                    }
                    break;
                
                case PathState.InvertedCenter:
                    if(GameMaster.Instance.GetRightCenterDirectioner())
                    {
                        path = pathfinder.GetRightInvertedTopPath();
                        currentPath = PathState.RightInvertedTop;
                    } else 
                    {
                        path = pathfinder.GetRightInvertedBottomPath();
                        currentPath = PathState.RightInvertedBottom;
                    }
                    break;

                case PathState.RightInvertedTop:
                case PathState.RightInvertedBottom:
                    path = pathfinder.GetRightInvertedStartPath();
                    currentPath = PathState.RightInvertedStart;
                    break;

                case PathState.RightInvertedStart:
                    GameMaster.Instance.PlayerScores();
                    Destroy(gameObject);
                    return;

                case PathState.RightStart:
                    if (GameMaster.Instance.GetRightDirectioner())
                    {
                        path = pathfinder.GetRightBottomPath();
                        currentPath = PathState.RightBottom;
                    } else 
                    {
                        path = pathfinder.GetRightTopPath();
                        currentPath = PathState.RightTop;
                    }
                    break;

                case PathState.RightBottom:
                    if(GameMaster.Instance.GetRightBottomDirectioner())
                    {
                        path = pathfinder.GetCenterPath();
                        currentPath = PathState.Center;
                    } else 
                    {
                        path = pathfinder.GetLeftInvertedBottomPath();
                        currentPath = PathState.LeftInvertedBottom;
                    }
                    break;
                
                case PathState.RightTop:
                    if(GameMaster.Instance.GetRightTopDirectioner())
                    {
                        path = pathfinder.GetCenterPath();
                        currentPath = PathState.Center;
                    } else 
                    {
                        path = pathfinder.GetLeftInvertedTopPath();
                        currentPath = PathState.LeftInvertedTop;
                    }
                    break;
                
                case PathState.Center:
                    if(GameMaster.Instance.GetLeftCenterDirectioner())
                    {
                        path = pathfinder.GetLeftInvertedTopPath();
                        currentPath = PathState.LeftInvertedTop;
                    } else 
                    {
                        path = pathfinder.GetLeftInvertedBottomPath();
                        currentPath = PathState.LeftInvertedBottom;
                    }
                    break;

                case PathState.LeftInvertedBottom:
                case PathState.LeftInvertedTop:
                    path = pathfinder.GetLeftInvertedStartPath();
                    currentPath = PathState.LeftInvertedStart;
                    break;

                case PathState.LeftInvertedStart:
                    Destroy(gameObject);
                    GameMaster.Instance.MLAgentScores();
                    return;
            }           
        target = path[pathIndex];            
    }
    void ResetIndex(){
        pathIndex = 0;
    }
}
