using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessDemo001 : MonoBehaviour
{


    public GameObject PF_chess1;
    public GameObject PF_chess2;
    public Vector3 startPosition;
    public float amount;

    public int gridSize = 4;


    void Start()
    {
        StartCoroutine(ChessFields());

  




    }

    IEnumerator ChessFields()
    {
        float scale_pf = _global.Global_Scale;
        GameObject[] ChessTmp = new GameObject[2];
        ChessTmp[0] = PF_chess1;
        ChessTmp[1] = PF_chess2;
        for (int i = 0; i < gridSize; i++)
            for (int j = 0; j < gridSize; j++)
            {
                Vector3 NewPos = new Vector3(scale_pf * i, 0.001f, scale_pf * j);
                GameObject ChTmp = Instantiate(ChessTmp[(i + j) % 2], NewPos, Quaternion.identity);
                ChTmp.transform.localScale = new Vector3(scale_pf, 0.1f, scale_pf);

                
                yield return new WaitForSeconds(0.005f);
            }
    }
}
