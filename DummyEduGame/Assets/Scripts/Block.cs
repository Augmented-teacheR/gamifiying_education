using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    velocity, distance, time
}
public class Block : MonoBehaviour
{
    [SerializeField]
    private BlockType type;
    [SerializeField]
    private float value;

    public Block(BlockType type, float value)
    {
        this.type = type;
        this.value = value;
    }

    public BlockType GetBlockType()
    {
        return this.type;
    }

    public float GetValue()
    {
        return this.value;
    }
}