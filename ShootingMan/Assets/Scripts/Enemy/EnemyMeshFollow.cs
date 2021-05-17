using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeshFollow : MonoBehaviour
{

    //For Collider that attached the enemies for checking if there is any player around them
    private EnemyAI _enemyAi;
    private Transform _playeritself;

    private void Awake()
    {
        //subsctribe the action
        _enemyAi = GetComponent<EnemyAI>();
        _enemyAi.OnEnemyMesh += _enemyAi_OnEnemyMesh;
    }

    private void _enemyAi_OnEnemyMesh(Transform player)
    {
        //work the action
        _playeritself = player;
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<EnemyMovement>().enabled = false;
       
    }
    private void Update()
    {
        if (_playeritself != null)
        {  
            //we dont want the enemies wait or stop when they see the player         
            GetComponent<NavMeshAgent>().SetDestination(_playeritself.position);       
        }
    }
}
