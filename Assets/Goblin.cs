using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    

    public float spd = 3;
    private Rigidbody2D rb;

    public Transform target; //finding the the points
    //public Transform spawnpoint;

    public int gearn = 0;

    public bool getG = false;
    public bool homepoint = false;
    public bool idlepoint = true;

   // public float spawnradius;
    public bool cancarry = false;

    public bool isright;

    public Animator anim;
    Vector2 move_direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isright = true;

        anim.SetBool("isfind", false);
        //idlepos = true;
    }

    private void Update()
    {
        

        if (!target)
        {
            
            FindBag();

        }
        else
        {
            
            RotateTowardsTarget();
        }

    }

    private void FixedUpdate()
    {
        if (idlepoint == false)
        {
            
            //rb.velocity = new Vector2(move_direction.x, move_direction.y) * spd;
            rb.MovePosition(new Vector2((transform.position.x + move_direction.x * spd * Time.deltaTime), transform.position.y + move_direction.y * spd * Time.deltaTime));
            
            //anim.SetFloat("spd", Mathf.Abs(rb.velocity.x));
            //anim.SetFloat("spd", rb.velocity.y);
        }
    }


    public void RotateTowardsTarget()
    {
        Vector3 targetdir = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(targetdir.y, targetdir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        move_direction = targetdir;

        
        
    }

    public void Flip()
    {
        isright = !isright;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

    public void FindBag()
    {
        if (GameObject.FindGameObjectWithTag("G"))
        {
            
            anim.SetBool("isfind", true);
            getG = true;
            homepoint = false;
            cancarry = false;
            isright = false;
            idlepoint = false;
            target = GameObject.FindGameObjectWithTag("G").transform;
            


        }

    }

    public void HomePoint()
    {


        if (GameObject.FindGameObjectWithTag("HomePoint"))
        {
            
            
            anim.SetBool("isfind", true);
            cancarry = true;
            target = GameObject.FindGameObjectWithTag("HomePoint").transform;
            
            if(isright == false)
            {
                Flip();
            }

        }

    }

    public void IdlePoint()
    {

        //target.transform.position = GetRndom();
        
        target = GameObject.FindGameObjectWithTag("IdlePoint").transform;
        


        if (isright == true)
        {
            isright = true;
            Flip();
        }

    }

    
    //Vector2 that need to return in order to have a complete value
    //public Vector2 GetRndom() { return (Vector2)spawnpoint.position + new Vector2(Random.Range(-spawnradius, spawnradius), Random.Range(-spawnradius, spawnradius)); }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawWireSphere(target.position, spawnradius);
        //Gizmos.DrawWireSphere(spawnpoint.position, spawnradius);
    }


}
