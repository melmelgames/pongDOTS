using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct SpeedIncreaseOverTimeData : IComponentData
{
    public float increasePerSecond;
}
