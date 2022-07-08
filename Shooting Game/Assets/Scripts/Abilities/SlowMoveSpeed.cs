using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoveSpeed : MonoBehaviour
{
    private Player player;
    private float decreaseAmount = 0.75f;

    public void IncreaseMoveSpeed()
    {
        player.GetComponent<Player>().currentSpeed *= decreaseAmount;
    }
}
