using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialValue;
    public Vector2 defaultValue;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize() { }
}
