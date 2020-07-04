using System;
using System.Collections;
using Rewired;

public class Character : Entity {
    public Player player;
    
    public enum CharPhase {
        One,
        Two,
        Three,
    }

    public CharPhase currentPhase = CharPhase.One;

    private void Awake() {
        player = ReInput.players.GetPlayer(0);
    }

    private void AddComponents() {
        components.Add(typeof(CharacterMovement), GetComponent<CharacterMovement>());
    }
}