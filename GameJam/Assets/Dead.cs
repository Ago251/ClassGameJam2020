using UnityEngine;

public class Dead : MonoBehaviour {
    public Transform spawn;

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if (other.CompareTag("Player")) {
            var cc = other.GetComponent<CharacterController>();
            cc.enabled = false;
            other.gameObject.transform.position = spawn.position;
            cc.enabled = true;
        }
    }
}
