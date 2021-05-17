using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishingGame : MonoBehaviour
{
    public static bool isfinishGame;
    [SerializeField] UIManager _UIevents;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isfinishGame = true;
            _UIevents.UpdateGameStatuslose();
        }

        if (other.gameObject.tag == "FinishLine")
        {
            isfinishGame= true;
            _UIevents.UpdateGameStatuswin();
        }
    }
 
}
