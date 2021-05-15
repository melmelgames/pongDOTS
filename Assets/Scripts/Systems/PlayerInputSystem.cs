using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class PlayerInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref PaddleMovementData movementData, in PaddleInputData inputData) => 
        {
            movementData.direction = 0;

            movementData.direction += Input.GetKey(inputData.upKey) ? 1 : 0;
            movementData.direction -= Input.GetKey(inputData.downKey) ? 1 : 0;
        }).Run();

        return default;
    }
}
