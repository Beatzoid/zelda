using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initalValue;

    public float runtimeValue;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        runtimeValue = initalValue;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize() { }
}
