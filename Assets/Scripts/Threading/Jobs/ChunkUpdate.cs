using UnityEngine;
using System;
using System.Collections;

public class ChunkUpdate : ThreadedJob
{

    const int chunkSize = 16;
    public MeshData OutData; // arbitary job data
    public Block[, ,] blocks = new Block[chunkSize, chunkSize, chunkSize];

    Chunk chunk;
    DateTime start;
    public void SetData(Chunk chunk, Block[,,] blocks)
    {
        this.chunk = chunk;
        this.blocks = blocks;
    }

    protected override void ThreadFunction()
    {

        OutData = new MeshData();
        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                for (int z = 0; z < chunkSize; z++)
                {
                    OutData = blocks[x, y, z].Blockdata(chunk, x, y, z, OutData);
                }
            }
        }
        start = DateTime.Now;
      //  OutData = chanceCalc.CardHelper.Getchance(hands, board);
    }
    protected override void OnFinished()
    {
        Debug.Log("<color=green>Thread Odds Took </color>:" + (DateTime.Now - start).TotalMilliseconds);
    }
}
