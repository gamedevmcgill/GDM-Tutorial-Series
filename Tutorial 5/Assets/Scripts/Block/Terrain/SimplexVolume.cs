using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplexVolume : IBlockSpawner
{

    public Vector3 volumeSize;
    public Vector3 startPoint;
    public Block blockPrefab;
    public float hole_prob = 0.3f;
    public float zoom; 
    SimplexNoise simplex = new SimplexNoise();

    public override List<Block> SpawnBlocks()
    {
        float convertProb = hole_prob * 255.0f;
        List<Block> spawned_blocks = new List<Block>();
        
        for(int length = 0; length < volumeSize.x; length++)
        {
            for (int width = 0; width < volumeSize.z; width++)
            {
                for (int height = 0; height < volumeSize.y; height++)
                {

                    float x = (float)length * blockPrefab.transform.localScale.x;
                    float z = (float)width * blockPrefab.transform.localScale.z;
                    float y = (float)height * blockPrefab.transform.localScale.y;

                    float rand = (float)simplex.getDensity(new Vector3(x, y, z) * zoom);
                    //Debug.Log(rand);

                    if (rand < convertProb) continue;
                    Block block = GameObject.Instantiate(blockPrefab, startPoint + new Vector3(x, y, z), Quaternion.identity) as Block;
                    spawned_blocks.Add(block);
                }
            }
        }
        return spawned_blocks;
    }

}
