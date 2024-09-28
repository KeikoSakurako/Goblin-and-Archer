using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landmine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Archer sh = collision.GetComponent<Archer>();

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            sh.anim.SetBool("isatk", true);

        }
    }

   
   

    

}
