using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huge : MonoBehaviour
{
    private float growSize = 1.25f;
    public void Expand()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * growSize, gameObject.transform.localScale.y * growSize);
        Debug.Log($"Player가 커졌습니다.");
    }
}
