using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public float startRotation = -80;

    private bool open = false;

    private void Start()
    {
        canvasGroup.alpha = 0;
        transform.localScale = Vector3.zero;
    }

    public void Open()
    {
        if (open) return;

        open = true;

        transform.LeanRotateZ(0, 1f).setEaseOutBounce();

        canvasGroup.LeanAlpha(0.8f, 0.5f);

        transform.LeanScale(Vector3.one, 0.5f);
    }

    public void Close()
    {
        open = false;

        transform.LeanRotateZ(startRotation, 0.6f).setEaseInBack().setEaseOutQuad();

        canvasGroup.LeanAlpha(0, 0.5f);

        transform.LeanScale(Vector3.zero, 0.5f);
    }
}