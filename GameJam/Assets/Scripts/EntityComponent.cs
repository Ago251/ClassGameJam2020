using UnityEngine;

public abstract class EntityComponent<T> : EntityComponent where T : Entity {
	protected T Entity { get; private set; }

	protected virtual void Awake() {
		Entity = GetComponent<T>();
		Debug.Assert(Entity != null, "No entity found", this);
	}
}

public abstract class EntityComponent : MonoBehaviour { }