using UnityEngine;

public class Pathfinder : MonoBehaviour {
    public GameObject leftStart;
    public GameObject leftBottom;
    public GameObject leftTop;
    public GameObject center;
    public GameObject rightStart;
    public GameObject rightBottom;
    public GameObject rightTop;
    public static Transform[] leftStartPath;
    public static Transform[] leftInvertedStartPath;
    public static Transform[] leftBottomPath;
    public static Transform[] leftInvertedBottomPath;
    public static Transform[] leftTopPath;
    public static Transform[] leftInvertedTopPath;
    public static Transform[] centerPath;
    public static Transform[] centerInvertedPath;
    public static Transform[] rightStartPath;
    public static Transform[] rightInvertedStartPath;
    public static Transform[] rightBottomPath;
    public static Transform[] rightInvertedBottomPath;
    public static Transform[] rightTopPath;
    public static Transform[] rightInvertedTopPath;

    void Start()
    {
        LeftStartPath();
        LeftBottomPath();
        LeftTopPath();
        CenterPath();
        RightStartPath();
        RightBottomPath();
        RightTopPath();
    }

    void LeftStartPath () 
    {        
        if (leftStart != null && leftStart.TryGetComponent<Path>(out var pathScript))
        {
            leftStartPath = pathScript.GetPath();
            leftInvertedStartPath = pathScript.GetInvertedPath();
        }
    }

    public Transform [] GetLeftStartPath()
    {
        return leftStartPath;
    }

    public Transform[] GetLeftInvertedStartPath()
    {
        return leftInvertedStartPath;
    }

    void LeftBottomPath() 
    {        
        if (leftBottom != null && leftBottom.TryGetComponent<Path>(out var pathScript))
        {
            leftBottomPath = pathScript.GetPath();
            leftInvertedBottomPath = pathScript.GetInvertedPath();
        }
    }

    public Transform [] GetLeftBottomPath()
    {
        return leftBottomPath;
    }

    public Transform[] GetLeftInvertedBottomPath()
    {
        return leftInvertedBottomPath;
    }

    void LeftTopPath()
    {        
        if (leftTop != null && leftTop.TryGetComponent<Path>(out var pathScript))
        {
            leftTopPath = pathScript.GetPath();
            leftInvertedTopPath = pathScript.GetInvertedPath();
        }
    }

    public Transform [] GetLeftTopPath()
    {
        return leftTopPath;
    }

    public Transform[] GetLeftInvertedTopPath()
    {
        return leftInvertedTopPath;
    }


    void CenterPath()
    {        
        if (center != null && center.TryGetComponent<Path>(out var pathScript))
        {
            centerPath = pathScript.GetPath();
            centerInvertedPath = pathScript.GetInvertedPath();
        }
    }

    public Transform [] GetCenterPath()
    {
        return centerPath;
    }

    public Transform[] GetInvertedCenterPath()
    {
        return centerInvertedPath;
    }

    void RightStartPath()
    {        
        if (rightStart!= null && rightStart.TryGetComponent<Path>(out var pathScript))
        {
            rightStartPath = pathScript.GetPath();
            rightInvertedStartPath = pathScript.GetInvertedPath();
        }
    }

    public Transform [] GetRightStartPath()
    {
        return rightStartPath;
    }

    public Transform[] GetRightInvertedStartPath()
    {
        return rightInvertedStartPath;
    }

    void RightBottomPath()
    {        
        if (rightBottom != null && rightBottom.TryGetComponent<Path>(out var pathScript))
        {
            rightBottomPath = pathScript.GetPath();
            rightInvertedBottomPath = pathScript.GetInvertedPath();
        }
    }

    public Transform [] GetRightBottomPath()
    {
        return rightBottomPath;
    }

    public Transform[] GetRightInvertedBottomPath()
    {
        return rightInvertedBottomPath;
    }
    
    void RightTopPath()
    {       
        if (rightTop != null && rightTop.TryGetComponent<Path>(out var pathScript))
        {
            rightTopPath = pathScript.GetPath();
            rightInvertedTopPath = pathScript.GetInvertedPath();
        }
    }

    public Transform [] GetRightTopPath()
    {
        return rightTopPath;
    }

    public Transform[] GetRightInvertedTopPath()
    {
        return rightInvertedTopPath;
    }

}