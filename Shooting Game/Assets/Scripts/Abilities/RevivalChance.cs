using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivalChance : MonoBehaviour
{
    private Player player;

    public void Revival()
    {
        player.GetComponent<Player>().revivalChance++;
    }
}
