using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSolider : MonoBehaviour
{
    public Material[] material = new Material[2];
    public MeshRenderer skin;
    public bool isBuy;



    public void OnInit()
    {

        int ran = Random.Range(0, 2);

        switch (ran)
        {
            case 0:
                isBuy = true;
                break;
            case 1:
                isBuy = false;
                break;
            default:
                break;
        }
        IsBuy();
    }

    public void IsBuy()
    {
        if (isBuy)
        {
            skin.material = material[0];
        }
        else
        {
            skin.material = material[1];
        }
    }

}
