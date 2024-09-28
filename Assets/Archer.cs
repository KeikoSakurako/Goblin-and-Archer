using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public Transform target;
    public Animator anim;
    public bool dect = false;

    public float range;

    //
    public GameObject bullet;
    public Transform atkpoint;
    public GameObject gun;

    public float forcemet;
   

    Vector2 dir;

    private void Start()
    {
        anim.SetBool("isatk", false);
    }

    private void Update()
    {

        Vector2 targetpos = target.position;

        dir = targetpos - (Vector2)transform.position;

        RaycastHit2D rayinfo = Physics2D.Raycast(transform.position, dir, range);


        if (rayinfo)
        {
            
            if (rayinfo.collider.gameObject.tag == "Player")
            {

                if (dect == false)
                {


                    dect = true;
                    anim.SetBool("isatk", true);



                }

            }
            else
            {

                if (dect == true)
                {
                    
                    dect = false;
                    anim.SetBool("isatk", false);
                }
            }

            if (dect)
            {

                gun.transform.right = dir;
                

            }



        }

    }

    public void Shoot()
    {

        GameObject bulins = Instantiate(bullet, atkpoint.position, Quaternion.identity);
        bulins.GetComponent<Rigidbody2D>().AddForce(dir * forcemet);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }



}
