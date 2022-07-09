using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public List<int> DotDamageTickTimers = new List<int>();
    public List<int> DotHealTickTimers = new List<int>();

    IEnumerator DotDamageCoroutine()
    {
        while (DotDamageTickTimers.Count > 0)
        {
            for (int i = 0; i < DotDamageTickTimers.Count; i++)
            {
                DotDamageTickTimers[i]--;
            }
            GameManager.gameManager.GetDamage(5);
            DotDamageTickTimers.RemoveAll(number => number == 0);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator DotHealCoroutine()
    {
        while (DotHealTickTimers.Count > 0)
        {
            for (int i = 0; i < DotHealTickTimers.Count; i++)
            {
                DotHealTickTimers[i]--;
            }
            GameManager.gameManager.HealHp(3);
            DotHealTickTimers.RemoveAll(number => number == 0);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ApplyDotDamage(int ticks)
    {
        if (DotDamageTickTimers.Count <= 0)
        {
            DotDamageTickTimers.Add(ticks);
            StartCoroutine(DotDamageCoroutine());
        }
        else
        {
            DotDamageTickTimers.Add(ticks);
        }
    }

    public void ApplyDotHeal(int ticks)
    {
        if (DotHealTickTimers.Count <= 0)
        {
            DotHealTickTimers.Add(ticks);
            StartCoroutine(DotHealCoroutine());
        }
        else
        {
            DotHealTickTimers.Add(ticks);
        }
    }
}
