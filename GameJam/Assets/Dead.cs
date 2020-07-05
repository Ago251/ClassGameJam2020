using UnityEngine;

public class Dead : MonoBehaviour {
    [SerializeField] private Transform spawn;

    private void Spawn(GameObject target) {
        Debug.Log("Spawn");
        target.transform.position = spawn.position;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Hit player");
            Spawn(other.gameObject);
        }
    }
}
