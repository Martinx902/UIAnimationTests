using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordData
{
    public Color wordColor;

    public float wordScale;

    public int startingWordIndex;

    public int wordLength;

    private Vector3[] charVertices;

    public WordData(int startingWordIndex, int wordLength, float wordScale = 1)
    {
        this.startingWordIndex = startingWordIndex;
        this.wordLength = wordLength;
        this.wordScale = wordScale;
    }
}