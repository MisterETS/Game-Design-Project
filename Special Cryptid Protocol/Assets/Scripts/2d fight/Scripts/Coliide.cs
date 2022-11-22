using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Coliide : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;

    private Material mat;
    private Color[] colors = { Color.yellow, Color.red };
    public GameObject GameObject;
    
    public BattleSystem BattleSystem;

    public void Awake()
    {

        mat = GetComponent<SpriteRenderer>().material;

    }
    // Use this for initialization
    void Start()
    {
        
    }

    IEnumerator Flash(float intervalTime)
    {
        mat.color = colors[1 % 2];
        yield return new WaitForSeconds(intervalTime);
        mat.color = Color.white;
        yield return new WaitForSeconds(intervalTime);
        mat.color = colors[1 % 2];
        yield return new WaitForSeconds(intervalTime);
        mat.color = Color.white;
    }










private IEnumerator EnableCollision(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        GetComponent<Collider2D>().enabled = true;
    }
    

    IEnumerator wait()
    {
        //animation of hit

        yield return new WaitForSeconds(1.5f);
    }


   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Resistance")
        {
            Debug.Log("hit");
            BattleSystem.numofattcks++;
            GetComponent<Collider2D>().enabled = false;
            source.PlayOneShot(clip);
            StartCoroutine(Flash(1f));
            StartCoroutine(EnableCollision(3));
            
            
        }
            

            

    }


   
}
