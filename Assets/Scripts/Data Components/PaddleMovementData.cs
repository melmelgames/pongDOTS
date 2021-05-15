using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct PaddleMovementData : IComponentData
{
    public int direction;
    public float speed;
}
