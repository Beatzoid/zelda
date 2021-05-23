using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject, ISerializationCallbackReceiver
{
    public float health = 6;

    public float runtimeHealth;

    public void OnAfterDeserialize()
    {
        runtimeHealth = health;
    }

    public void OnBeforeSerialize() { }
}
