using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public CanvasGroup canvas;

    [Range(0, 1f)]
    public float animTime = 0.5f;

    public void OnEnable()
    {
        canvas.alpha = 0;
        canvas.LeanAlpha(0.8f, animTime);

        transform.position = new Vector2(transform.position.x, -Screen.height / 2);
        transform.LeanMoveLocalY(0, animTime).delay = 0.1f;

        transform.localScale = Vector3.zero;
        transform.LeanScale(Vector3.one, animTime);
    }

    public void CloseSettings()
    {
        StartCoroutine(CloseCoroutine());
    }

    private IEnumerator CloseCoroutine()
    {
        canvas.LeanAlpha(0, animTime);

        transform.LeanMoveLocalY(-Screen.height / 2, animTime).delay = 0.1f;

        transform.LeanScale(Vector3.zero, animTime);

        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }
}