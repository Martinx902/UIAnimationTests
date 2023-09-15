using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWordAnimator : MonoBehaviour
{
    [Range(0, 10f)]
    public float animIntensity = 3f;

    private TMP_Text textMesh;

    private Mesh mesh;

    private Vector3[] vertices;

    private List<int> wordIndexes;
    private List<int> wordLengths;

    // Start is called before the first frame update
    private void Start()
    {
        textMesh = GetComponent<TMP_Text>();

        wordIndexes = new List<int> { 0 };
        wordLengths = new List<int>();

        //Detect the different words in the text

        string s = textMesh.text;

        for (int index = s.IndexOf(' '); index > -1; index = s.IndexOf(' ', index + 1))
        {
            wordLengths.Add(index - wordIndexes[wordIndexes.Count - 1]);
            wordIndexes.Add(index + 1);
        }
        wordLengths.Add(s.Length - wordIndexes[wordIndexes.Count - 1]);
    }

    // Update is called once per frame
    private void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        //Iterate through every word in the text
        for (int i = 0; i < wordIndexes.Count; i++)
        {
            int wordIndex = wordIndexes[i];
            Vector3 offset = Wobble(Time.time + i);

            //Iterate through every character of the word
            for (int y = 0; y < wordLengths[i]; y++)
            {
                TMP_CharacterInfo c = textMesh.textInfo.characterInfo[wordIndex + y];

                int index = c.vertexIndex;

                //Add the offset
                vertices[index] += offset;
                vertices[index + 1] += offset;
                vertices[index + 2] += offset;
                vertices[index + 3] += offset;
            }
        }

        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    private Vector3 Wobble(float time)
    {
        return new Vector3(Mathf.Sin(time * animIntensity), Mathf.Cos(time * animIntensity), 0);
    }
}