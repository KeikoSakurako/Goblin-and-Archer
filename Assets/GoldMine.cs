using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    [SerializeField] private float spawnrate = 1f;
    [SerializeField] private GameObject[] GPrefab;
    [SerializeField] private bool canspawn = true;
    [SerializeField] public Transform gpoint;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnrate);


        while (canspawn)
        {
            yield return wait;

            int rand = Random.Range(0, GPrefab.Length);
            GameObject Gtospawn = GPrefab[rand];

            //Original this is have no reference and its
            //Instantiate(Gtospawn, gpoint.position, Quaternion.identity);

            //This is have a reference for the prefab and on in the object (can be also fix by getting or set another variable ne)
            Gtospawn = Instantiate(Gtospawn, gpoint.position, Quaternion.identity);

       
        
            float dropForce = 7f;
            Vector2 dropDir = new Vector2(Random.Range(-1f, 1), Random.Range(-1f, -0.5f));
            Gtospawn.GetComponent<Rigidbody2D>().AddForce(dropDir * dropForce, ForceMode2D.Impulse);
            print(dropDir * dropForce);
        }

    }



}
