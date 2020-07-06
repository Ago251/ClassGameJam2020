using UnityEngine;

public class Dead : MonoBehaviour {
    [SerializeField] private Transform spawn;

    private void Spawn(GameObject target) {
        target.transform.position = spawn.position;
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("Player")) {
            Spawn(other.gameObject);
        }
    }
}
