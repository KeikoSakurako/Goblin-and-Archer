using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManage : MonoBehaviour
{
    [SerializeField]public GameObject player;
    [SerializeField] public Transform spawnplayer;

    private void Start()
    {
        Instantiate(player, spawnplayer.position, Quaternion.identity);
    }
    
}
