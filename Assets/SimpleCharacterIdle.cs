using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterIdle : MonoBehaviour
{
    [Range(0, 1f)]
    public float animTime = 0.5f;

    private void Start()
    {
        transform.LeanMoveLocal(new Vector2(transform.localPosition.x, transform.localPosition.y + 50), 0.5f).setEaseOutQuart().setLoopPingPong();
    }
}