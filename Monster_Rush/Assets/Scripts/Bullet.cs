using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    // Speed
    public float speed = 10;
    
    // Target (set by Tower)
    public Transform target;    
    
    void FixedUpdate() {    
        // Still has a Target?
        if (target) {
            // Fly towards the target        
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        } else {
            // Otherwise destroy self
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider co) {
        Health health = co.GetComponentInChildren<Health>();
        if (health) {
            if (StoreMgr.Instance.towerSpecise == StoreMgr.TowerSpecise.primary)
            {
                health.decrease(1);
            }
            else if (StoreMgr.Instance.towerSpecise == StoreMgr.TowerSpecise.intermediate)
            {
                health.decrease(2);
            }
            else if (StoreMgr.Instance.towerSpecise == StoreMgr.TowerSpecise.advance)
            {
                health.decrease(3);
            }
            else if (StoreMgr.Instance.towerSpecise == StoreMgr.TowerSpecise.nightmare)
            {
                health.decrease(4);
            }
            Destroy(gameObject);
        }
    }
}
