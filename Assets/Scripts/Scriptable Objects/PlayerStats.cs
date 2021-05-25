using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject, ISerializationCallbackReceiver
{
    public float health = 6;

    public float runtimeHealth;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        runtimeHealth = health;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize() { }
}
