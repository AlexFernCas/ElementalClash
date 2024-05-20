using System.Collections;
using UnityEngine;

public class Simulator : MonoBehaviour
{

    private int action;
    public MLAgent mlAgent;
    readonly System.Random random = new System.Random();

    void Start()
    {
        StartCoroutine(Action());
    }

    public IEnumerator Action()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
            int randomNumber = random.Next(0, 4);
            mlAgent.SimulateAction(randomNumber);
        }
    }
}
