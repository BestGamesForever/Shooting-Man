using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //Enemies have Two healt And Shootings damage 1 for every shot.
    [SerializeField] private int TotalHealt = 2;
    int currentHealth;
    public static int killedEnemy;
   
    private void OnEnable()
    {
        currentHealth = TotalHealt;       
    }
    public void DamageTaken(int DamageAmt)
    {
        currentHealth -= DamageAmt;
        if (currentHealth==0)
        {
            gameObject.SetActive(false);
            //We increase the killed enemies one by one to know if there any left behind and finish the game.
            killedEnemy++;
            Debug.Log("killed" + killedEnemy);
          
        }
    }  
}
