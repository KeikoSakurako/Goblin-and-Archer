using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gbag : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Goblin p = collision.GetComponent<Goblin>();
        if (collision.gameObject.CompareTag("Player") && p.cancarry == false)
        {
            p.target = null;
            p.homepoint = true;
            p.getG = false;
            p.isright = false;
            
            if (p.cancarry == false)
            {
                p.HomePoint();
                Destroy(gameObject);
            }
            
         }
                
        
    }


}
