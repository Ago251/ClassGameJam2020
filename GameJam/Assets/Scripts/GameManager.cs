using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform mapCenter;
	public Orb firstOrb;
	public Orb secondOrb;
	public Orb thirdOrb;

	public GameObject thirdWall;

	private event Action ReallocatePlayer;

	public PlayerMovement character;

	public CinemachineVirtualCamera bigCamera;

	void Start() {
		ReallocatePlayer += CharacterToCenter;
		character.canJump = false;
		firstOrb.orbDestroyed += EnableJumpToPlayer;
		secondOrb.orbDestroyed += () => RemoveWall(3);
	}

	private void Update() {
		if (character.player.GetButtonDown("Interact")) {
			if (firstOrb != null) {
				if (Vector3.Distance(character.transform.position, firstOrb.transform.position) < 2f) {
					firstOrb.Dissipate();
				}
			}
			if (secondOrb != null) {
				if (Vector3.Distance(character.transform.position, secondOrb.transform.position) < 2f) {
					secondOrb.Dissipate();
				}
			}
			if (thirdOrb != null) {
				if (Vector3.Distance(character.transform.position, thirdOrb.transform.position) < 2f) {
					thirdOrb.Dissipate();
				}
			}
		}
	}

	private void EnableJumpToPlayer() {
		character.canJump = true;
		ReallocatePlayer?.Invoke();
	}

	private void CharacterToCenter() {
		character.transform.position = mapCenter.position;
	}

	private void RemoveWall(int id) {
		switch (id) {
			case 3:
				thirdWall.gameObject.SetActive(false);
				break;
		}
		CharacterToCenter();
	}

	[Button]
	public void Grow() {
		bigCamera.Priority = 100;
		StartCoroutine(GrowRoutine());

	}

	private IEnumerator GrowRoutine() {
		while (character.transform.localScale.x< 4) {
			character.transform.localScale += new Vector3(Time.deltaTime,Time.deltaTime,Time.deltaTime)/3;
			yield return null;
		}
	}
}