using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShiftTile : MonoBehaviour
{
    // Start is called before the first frame update


    public float amount = 0.4f;

    [SerializeField] float scale_speed = _global.Global_Speed;
    [HideInInspector] private Text Text__info001;
    [HideInInspector] private Text Text__info002;
    [HideInInspector] private Text Text__info003;

    [SerializeField] float CoroutineTimerefresh = 0.1f;

    [SerializeField] float TimeToMove = 3.00f;
    private float TimePassed = 0.00f;

    int CorutCalls = 0;





    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {

        Text__info001 = GameObject.Find("Text__info001").GetComponent<Text>();
        Text__info002 = GameObject.Find("Text__info002").GetComponent<Text>();
        Text__info003 = GameObject.Find("Text__info003").GetComponent<Text>();
        Text__info003.text = "Text__info003";
        

        startPosition = this.transform.position;
        this.transform.position = this.transform.position + Vector3.up * amount;
        StartCoroutine(CorChess());

    }



    IEnumerator CorChess()
    {
        

        
        while (this.transform.position.y - startPosition.y > 0.05f && TimePassed < TimeToMove)
        {
            CorutCalls++;
            TimePassed += Time.deltaTime;
            this.transform.position = Vector3.Lerp(this.transform.position, startPosition, TimePassed / TimeToMove);
            
           // yield return null;
            yield return new  WaitForSeconds(CoroutineTimerefresh);
        }

      
       
    }

}



