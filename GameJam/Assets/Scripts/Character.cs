using System.Collections;
using DefaultNamespace;

public class Character : Entity
{

    private void AddComponents() {
        components.Add(typeof(CharacterMovement), GetComponent<CharacterMovement>());
    }
}