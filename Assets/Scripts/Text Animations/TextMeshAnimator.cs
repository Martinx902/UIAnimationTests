using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshAnimator : MonoBehaviour
{
    public float animIntensity = 3f;

    [Range(0, 0.1f)]
    public float gradientSpeed = 0.1f;

    [Range(0, 5f)]
    public float gradientTimeBetweenChange = 1f;

    private TMP_Text textMesh;

    private Mesh mesh;

    private Vector3[] vertices;

    public Gradient gradientColor;

    private void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        Color[] colors = mesh.colors;

        for (int i = 0; i < vertices.Length; i++)
        {
            //Updates the vertex position
            vertices[i] += Wobble(Time.time + i);

            //Updates the vertex color
            colors[i] = gradientColor.Evaluate(Mathf.Repeat(Time.time + vertices[i].y * gradientSpeed, gradientTimeBetweenChange));
        }

        //Set the mesh and force to update

        mesh.vertices = vertices;
        mesh.colors = colors;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    private Vector3 Wobble(float time)
    {
        return new Vector3(Mathf.Sin(time * animIntensity), Mathf.Cos(time * animIntensity), 0);
    }
}