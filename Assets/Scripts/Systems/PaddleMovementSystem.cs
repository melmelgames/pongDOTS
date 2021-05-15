using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class PaddleMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;
        float yBound = GameManager.main.yBound;

        Entities.ForEach((ref Translation translation, in PaddleMovementData data) => 
        {
            translation.Value.y = math.clamp(translation.Value.y + (data.speed * data.direction * deltaTime), -yBound, yBound);
        }).Run();

        return default;
    }
}
