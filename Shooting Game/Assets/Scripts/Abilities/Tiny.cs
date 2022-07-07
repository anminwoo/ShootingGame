using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiny : MonoBehaviour
{
    private float reduceSize = 0.90f;
    void Minimize()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * reduceSize, gameObject.transform.localScale.y * reduceSize);
        Debug.Log($"Player가 작아졌습니다.");
    }
}
