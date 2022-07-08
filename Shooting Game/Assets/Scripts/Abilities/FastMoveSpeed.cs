using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMoveSpeed : MonoBehaviour
{
    private Player player;
    private float speedBonus = 1.2f;

    public void IncreaseMoveSpeed()
    {
        player.GetComponent<Player>().currentSpeed *= speedBonus;
    }
}
