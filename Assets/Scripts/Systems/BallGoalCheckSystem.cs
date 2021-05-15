using Unity.Entities;
using Unity.Transforms;
using Unity. Collections;
using Unity.Mathematics;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class BallGoalCheckSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);


        Entities
            .WithAll<BallTag>()
            .WithoutBurst()
            .ForEach((Entity entity, in Translation translation) =>
        {
            float3 position = translation.Value;
            float bound = GameManager.main.xBound;

            if(position.x >= bound)
            {
                GameManager.main.PlayerScored(0);
                ecb.DestroyEntity(entity);
            }

            if(position.x <= -bound)
            {
                GameManager.main.PlayerScored(1);
                ecb.DestroyEntity(entity);
            }
        }).Run();

        ecb.Playback(EntityManager);
        ecb.Dispose();

        return default;
    }
}
