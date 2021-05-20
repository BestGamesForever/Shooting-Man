using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyAI : MonoBehaviour
{
    
    //For Nav mesh Agent to Follow the Player
    public event Action<Transform> OnEnemyMesh = delegate { };   
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
      
        
        if (player!=null)
        {
            OnEnemyMesh(player.transform);           
        }          

    }
}
