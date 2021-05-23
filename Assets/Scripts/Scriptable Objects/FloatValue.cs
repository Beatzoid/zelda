using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initalValue;

    public float runtimeValue;

    public void OnAfterDeserialize()
    {
        runtimeValue = initalValue;
    }

    public void OnBeforeSerialize() { }
}
