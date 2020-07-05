using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform mapCenter;
    public Orb firstOrb;
    public Orb secondOrb;
    public Orb thirdOrb;

    public GameObject secondWall;
    public GameObject thirdWall;

    private event Action ReallocatePlayer;

    public PlayerMovement character;
    void Start() {
        ReallocatePlayer += CharacterToCenter;
        character.canJump = false;
        firstOrb.orbDestroyed += EnableJumpToPlayer;
        firstOrb.orbDestroyed += () => RemoveWall(2);
        secondOrb.orbDestroyed += () => RemoveWall(3);
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
            case 2:
                secondWall.gameObject.SetActive(false);
                break;
            case 3:
                thirdWall.gameObject.SetActive(false);
                break;
        }
    }
}
