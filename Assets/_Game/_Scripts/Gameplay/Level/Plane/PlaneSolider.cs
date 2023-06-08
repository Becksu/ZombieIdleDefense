using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSolider : MonoBehaviour
{
    public GameObject planeSolider;
    public List<GameObject> soliderPrefab = new List<GameObject>();
    public List<Vector3> posSolider = new List<Vector3>();
    public int currentCountPlaneSolider;
    private void Awake()
    {
        planeSolider = Resources.Load<GameObject>("Level/CubeSolider/CubePositionSolider");
        AddSoliderInList();
    }
    private void Start()
    {
        GenPosition();
        GenSolider();
    }

    public void GenPosition()
    {
        float posX = 7;
        float posZ = 9;
        for(int i = 0; i < 3; i++)
        {
            posX = 7;
            posZ += 3;
            for(int j = 0; j < 3; j++)
            {
                GameObject go = Instantiate(planeSolider, transform);
                CubeSolider cubeSolider = go.GetComponent<CubeSolider>();
                posX -= 3;
                cubeSolider.transform.position = new Vector3(posX, 0, posZ);
                posSolider.Add(cubeSolider.transform.position);
                cubeSolider.OnInit();
            }
        }
    }
    public void GenSolider()
    {
        for (int i = 0; i < currentCountPlaneSolider; i++)
        {
            int ran = Random.Range(0, 6);
            GameObject soliderGo = Instantiate(soliderPrefab[ran], transform);
            Solider solider = soliderGo.GetComponent<Solider>();
            solider.transform.position = posSolider[i];
        }
    }
    public void AddSoliderInList()
    {
        for(int i = 0; i < 6; i++)
        {
            GameObject go = null;
            switch (i)
            {

                case 0:
                    go = Resources.Load<GameObject>("Solider/Troop");
                    break;
                case 1:
                    go = Resources.Load<GameObject>("Solider/Demotinolis");
                    break;
                case 2:
                    go = Resources.Load<GameObject>("Solider/MaskMan");
                    break;
                case 3:
                    go = Resources.Load<GameObject>("Solider/Bazoka");
                    break;
                case 4:
                    go = Resources.Load<GameObject>("Solider/Technician");
                    break;
                case 5:
                    go = Resources.Load<GameObject>("Solider/FalmethTower");
                    break;
                default:
                    break;
            }
            soliderPrefab.Add(go);
        }
    }

}
