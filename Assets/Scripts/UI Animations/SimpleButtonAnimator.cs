using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButtonAnimator : MonoBehaviour
{
    public void OnHover()
    {
        transform.LeanScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
    }

    public void OnExit()
    {
        transform.LeanScale(Vector3.one, 0.1f);
    }

    public void OnClick()
    {
        transform.LeanScale(new Vector3(1.3f, 1.3f, 1.3f), 0.1f);

        transform.LeanScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f).delay = 0.1f;
    }
}