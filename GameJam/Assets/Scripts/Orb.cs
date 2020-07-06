using System;
using System.Collections;
using Boo.Lang.Environments;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(SphereCollider))]
public class Orb : MonoBehaviour {

	public event Action orbDestroyed;
	private VisualEffect vfx;
	private float actualDissipation = 1;
	public GameObject obj;
	public Color color;
	public Material material;

	private void Awake() {
		vfx = GetComponent<VisualEffect>();
		orbDestroyed += ActivePlatform;
	}

	private IEnumerator OrbDissipation() {
		while (actualDissipation <= 50) {
			actualDissipation += Time.deltaTime * 10;
			vfx.SetFloat("Size", 1/actualDissipation);
			vfx.SetFloat("Dissipazione", actualDissipation);
			yield return null;
		}
		orbDestroyed?.Invoke();
		Destroy(gameObject);
	}

	private void ActivePlatform() {
		obj.GetComponent<Renderer>().material = material;
		obj.GetComponent<MeshRenderer>().material.color = color;
	}
	
	public void Dissipate() {
		StartCoroutine(OrbDissipation());
	}

}