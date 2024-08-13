using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;
    Slime enemy;
    public GameObject Blood;
    private void Start() {
        Destroy(gameObject, 4f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Enemy"){
            enemy = other.gameObject.GetComponent<Slime>();
            enemy.takeDame(2);
            GameObject bloodInstance = Instantiate(Blood, transform.position, Quaternion.identity);
            Destroy(bloodInstance, 1f);
            Destroy(gameObject);
        }
    }
}
