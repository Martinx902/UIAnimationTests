using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordData
{
    public Color wordColor;

    public int[] charIndexes;

    public Vector3[] vertices;

    public WordData(Color wordColor, int[] charIndexes, Vector3[] vertices)
    {
        this.wordColor = wordColor;
        this.charIndexes = charIndexes;
        this.vertices = vertices;
    }
}