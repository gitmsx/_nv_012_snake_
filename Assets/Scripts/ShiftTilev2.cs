using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftTilev2 : MonoBehaviour
{
    // Start is called before the first frame update


    public float amount = 0.4f;

    [SerializeField] float scale_speed = _global.Global_Speed;
    [SerializeField] float LerpInx = 1.01f;
    [SerializeField] float Accelerate_lerp_repeats_cicles = 0.001f;
    int CiclesComplete=0;


        Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {

        startPosition = this.transform.position;
        this.transform.position = this.transform.position + Vector3.up * amount;
         
        //print(startPosition);
        //print(this.transform.position);
        //print(" ---- ");


        StartCoroutine(CorChess());
        
    }



    IEnumerator CorChess( )
    {


      
        
        while (this.transform.position.y - startPosition.y > 0.05f)
        {
            
            this.transform.position = Vector3.Lerp(this.transform.position, startPosition, LerpInx+ (CiclesComplete++) * (Accelerate_lerp_repeats_cicles));
        yield return new WaitForSeconds(scale_speed);
        }
        this.transform.position = startPosition;
    }







}



