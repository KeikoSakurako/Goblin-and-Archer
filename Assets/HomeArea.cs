using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Goblin home = collision.GetComponent<Goblin>();
            home.gearn++;
            
            Debug.Log("Earn Gold: " + home.gearn);

            
            if (GameObject.FindGameObjectWithTag("G"))
                {
                home.homepoint = false;
                home.idlepoint = false;
                home.cancarry = false;
                home.isright = true;
                home.Flip();
                home.FindBag();
                    
            }
            else
                {
                home.getG = false;
                home.homepoint = true;
                //home.idlepos = true;
                home.IdlePoint();
                }
                

        }
        


    }
}
