using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItemScript : MonoBehaviour
{
    public GameObject drop;

    [Range(0,100)]
    public float dropPercentage;

    private void OnDestroy() {
        float dropChance = Random.Range(0,100);
        if(dropChance <= dropPercentage)
            Instantiate(drop,transform.position,drop.transform.rotation);
    }
}
