using UnityEngine;

public class Platform : MonoBehaviour
{ 
	public bool isActive;
	public bool solution;
	private Renderer renderer;
	private Code puzzle;

	private void Start() {
		renderer = GetComponent<Renderer>();
		puzzle = FindObjectOfType<Code>();
	}

	public void Active() {
		isActive = true;
		renderer.material.color = Color.yellow;
	}
	
	public void Disable() {
		isActive = false;
		renderer.material.color = Color.white;
	}
	
	private void OnTriggerEnter(Collider other) {
		// Debug.Log("Hit");
		if (other.gameObject.CompareTag("Player") && !puzzle.completed) {
			Active();
		}
	}
}
