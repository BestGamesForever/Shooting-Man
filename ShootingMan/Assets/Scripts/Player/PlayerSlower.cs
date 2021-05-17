using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSlower : MonoBehaviour
{
    public event Action<float> OnHitWall = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player!=null)
        {
            OnHitWall(player.PlayerSpeed);
        }
    }
}
