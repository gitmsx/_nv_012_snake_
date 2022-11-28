using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShiftTile : MonoBehaviour
{
    // Start is called before the first frame update
    public int copia;
    public int copiai;
    public int copiay;

    public float amount = 0.4f;

    [SerializeField] float scale_speed = _global.Global_Speed;
    [HideInInspector] private Text Text__info001;
    [HideInInspector] private Text Text__info002;
    [HideInInspector] private Text Text__info003;

    [SerializeField] float CoroutineTimerefresh = 0.1f;

    [SerializeField] float TimeToMove = 3.00f;
    private float TimePassed = 0.00f;

    int CorutCalls = 0;
     int gridSizeGet = _global.gridSize ;
    AudioSource audioSource;
    [SerializeField] AudioClip flySoundWood;
    [SerializeField] AudioClip StartSound;


    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Text__info001 = GameObject.Find("Text__info001").GetComponent<Text>();
        Text__info002 = GameObject.Find("Text__info002").GetComponent<Text>();
        Text__info003 = GameObject.Find("Text__info003").GetComponent<Text>();
        Text__info003.text = "Text__info003";
        

        startPosition = this.transform.position;
        this.transform.position = this.transform.position + Vector3.up * amount;
        audioSource.PlayOneShot(StartSound);
        StartCoroutine(CorChess());

    }



    IEnumerator CorChess()
    {
        

        
        while (this.transform.position.y - startPosition.y > 0.08f && TimePassed< (TimeToMove + copia / gridSizeGet))
        {
            CorutCalls++;
            TimePassed += Time.deltaTime;
            this.transform.position = Vector3.Lerp(this.transform.position, startPosition, (TimePassed) / (TimeToMove + copia / gridSizeGet));



            // transform.eulerAngles = new Vector3(transform.eulerAngles.x, yrotation2, transform.eulerAngles.z);
            transform.transform.rotation = Quaternion.Lerp(transform.transform.rotation, Quaternion.Euler(0, 180, 0), (TimePassed) / (TimeToMove + copia / gridSizeGet));

            // yield return null;
            yield return new  WaitForSeconds(CoroutineTimerefresh);
        }

        this.transform.position = startPosition;
        transform.transform.rotation = Quaternion.Euler(0, 180, 0);


        //        audioSource.Stop();
        audioSource.PlayOneShot(flySoundWood);

        //  print(copia);

    }

}



