using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coliide : MonoBehaviour
{

   
   


    private IEnumerator EnableCollision(float delay)
    {
         
        yield return new WaitForSeconds(delay);
        GetComponent<Collider2D>().enabled = true;
    }
    public GameObject GameObject;
    public BattleSystem BattleSystem;

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
            StartCoroutine(EnableCollision(3));
            
            
        }
            

            

    }


   
}
