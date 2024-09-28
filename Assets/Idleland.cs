using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idleland : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Goblin idw = collision.GetComponent<Goblin>();
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //idw.idlepos = true;
            idw.idlepoint = true;
            idw.homepoint = false;
            idw.target = null;
            idw.anim.SetBool("isfind", false);

            if (!idw.target)
            {

                idw.FindBag();

            }
            else
            {
                //idw.pointidle = true;
                idw.RotateTowardsTarget();
            }

        }
    }

   
}
