﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(SphereCollider))]
public class Orb : MonoBehaviour {

	public event Action orbDestroyed;
	private VisualEffect vfx;
	private float actualDissipation = 1;
	public GameObject obj;
	public Color color;

	private void Awake() {
		vfx = GetComponent<VisualEffect>();
		orbDestroyed += () => obj.GetComponent<MeshRenderer>().material.color = color;
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
	
	public void Dissipate() {
		StartCoroutine(OrbDissipation());
	}

}