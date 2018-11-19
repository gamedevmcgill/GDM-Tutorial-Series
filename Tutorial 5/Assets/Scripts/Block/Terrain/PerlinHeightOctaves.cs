using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinHeightOctaves : IBlockSpawner
{
    [System.Serializable]
    public struct Octave
    {
        public float contribution;
        public float zoom;
    }

    public int width;
    public int length;
    public Octave[] octaves;
    public float max_height;
    public Vector3 startPoint;
    public Block blockPrefab;
    float normalization = 0.0f;

    public override List<Block> SpawnBlocks()
    {
        normalization = 0.0f;
        foreach (Octave o in octaves)
        {
            normalization += Mathf.Abs(o.contribution);
        }

        List<Block> spawned_blocks = new List<Block>();
        for (int r = 0; r < width; r++)
        {
            for (int c = 0; c < length; c++)
            {
                float blockHeight = GetPerlin(r, c) * max_height;

                float x = (float)r * blockPrefab.transform.localScale.x;
                float z = (float)c * blockPrefab.transform.localScale.z;

                Block block = GameObject.Instantiate(blockPrefab, startPoint + new Vector3(x, blockHeight * 0.5f, z), Quaternion.identity) as Block;
                block.gameObject.transform.localScale = (new Vector3(blockPrefab.transform.localScale.x, blockPrefab.transform.localScale.y * blockHeight, blockPrefab.transform.localScale.z));
                spawned_blocks.Add(block);
            }
        }

        return spawned_blocks;
    }

    float GetPerlin(int r, int c)
    {
        float blockHeight = 0.0f;

        if (octaves.Length == 0)
        {
            return 1.0f;
        }

        foreach (Octave o in octaves)
        {
            blockHeight += o.contribution * Mathf.PerlinNoise(r * o.zoom / width, c * o.zoom / length);
        }
        return blockHeight / normalization;
    }
}
