using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class TextAnimator : MonoBehaviour
{
    [SerializeField]
    private EffectDetector effectDetector;

    private TMP_Text textMesh;

    private Mesh mesh;

    private Vector3[] normalVertices;

    private Dictionary<WordData, TextEffect> specialAnimations;

    // Start is called before the first frame update
    private void Start()
    {
        textMesh = GetComponent<TMP_Text>();

        string s = textMesh.text;

        //Detect special characters in the text

        foreach (Effect effect in effectDetector.effects)
        {
            //Ver si el caracter expuesto es un char esp

            if (s.Contains(effect.specialCharacter))
            {
                //Si lo contiene registrar todos sus indexes

                int[] indexes = AllIndexesOf(s, effect.specialCharacter.ToString()).ToArray();

                //Ir desde el primer index hasta el segundo index recogiendo los datos de por medio

                int lastCharFrom = 0;

                for (int i = 0; i < indexes.Length; i += 2)
                {
                    string charToLookAt = s[indexes[i]].ToString();

                    //Get the pos of the sp. chars

                    int partFrom = s.IndexOf(charToLookAt, lastCharFrom) + charToLookAt.Length;
                    int partTo = s.IndexOf(charToLookAt, partFrom);

                    //Start to look from the end of the last sp. char the next word

                    lastCharFrom = partTo + 1;

                    //Extract the word that is between the chars

                    string result = s.Substring(partFrom, partTo - partFrom);

                    //Save the word and the text effect linked to it

                    Debug.Log(result);
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public static IEnumerable<int> AllIndexesOf(string str, string searchstring)
    {
        int minIndex = str.IndexOf(searchstring);
        while (minIndex != -1)
        {
            yield return minIndex;
            minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
        }
    }
}