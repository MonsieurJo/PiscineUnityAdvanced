using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour {

    // Use this for initialization
    public void OnCollisionEnter(Collision collision)
    {
        PlayerManager player = collision.gameObject.GetComponentInParent<PlayerManager>();
        if (player)
        {
            player.Kill();
        }
    }
}
