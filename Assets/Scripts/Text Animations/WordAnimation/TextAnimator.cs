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

    private List<int> wordIndexes;
    private List<int> wordLengths;

    private void Awake()
    {
        if (specialAnimations == null)
            specialAnimations = new Dictionary<WordData, TextEffect>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        textMesh = GetComponent<TMP_Text>();

        wordIndexes = new List<int> { 0 };
        wordLengths = new List<int>();

        string s = textMesh.text;

        GetTextWords(s);

        //Detect special characters in the text

        foreach (Effect effect in effectDetector.effects)
        {
            if (s.Contains(effect.specialCharacter))
            {
                //Get all the positions of the char in the text

                int[] indexes = AllIndexesOf(s, effect.specialCharacter.ToString()).ToArray();

                //Get the word between the chars for every par of them there is

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

                    WordData w = new WordData(s.IndexOf(result[0]), result.Length);

                    TextEffect te = new TextEffect();

                    //TBD: Create the Text Effect generator based on the enum and call it here.

                    specialAnimations.Add(w, te);

                    Debug.Log(result);
                }
            }
        }
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

    private void GetTextWords(string text)
    {
        string s = textMesh.text;

        for (int index = s.IndexOf(' '); index > -1; index = s.IndexOf(' ', index + 1))
        {
            wordLengths.Add(index - wordIndexes[wordIndexes.Count - 1]);

            wordIndexes.Add(index + 1);
        }

        wordLengths.Add(s.Length - wordIndexes[wordIndexes.Count - 1]);
    }
}