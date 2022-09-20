using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    void Start()
    {
        StartCoroutine(destroyAfterTime());
    }

    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.GetComponent<EnemyBaseScript>()){
            other.transform.GetComponent<EnemyBaseScript>().TakeDamage(10);
            Destroy(this.gameObject);
        }
    }
    IEnumerator destroyAfterTime(){
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
