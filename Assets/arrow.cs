using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private GameObject player;

    
    public float force = 100f;

    private float timer;
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 s = player.transform.position - transform.position;
       

        float rot = Mathf.Atan2(-s.y, -s.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);

    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Goblin at = collision.GetComponent<Goblin>();
        if (collision.gameObject.CompareTag("Player"))
        {
                at.getG = false;
                at.cancarry = false;

            if (at.isright == true && at.homepoint == true)
            {
                    if (GameObject.FindGameObjectWithTag("G"))
                    {
                        at.Flip();
                  
                     }
             }
                

                at.FindBag();
                Destroy(gameObject);
        }
        



      }


 }

