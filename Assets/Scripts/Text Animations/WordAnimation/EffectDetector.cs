using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Effect Detector"))]
public class EffectDetector : ScriptableObject
{
    [SerializeField]
    private List<Effect> effects = new List<Effect>();

    private Dictionary<char, TextEffect> effectDictionary;

    private void OnValidate()
    {
        if (effectDictionary == null)
            effectDictionary = new Dictionary<char, TextEffect>();

        foreach (Effect effect in effects)
        {
            if (!effectDictionary.ContainsKey(effect.specialCharacter))
                effectDictionary.Add(effect.specialCharacter, effect.effect);
        }
    }
}

[System.Serializable]
public class Effect
{
    public char specialCharacter;
    public TextEffect effect;

    public Effect(char specialCharacter, TextEffect effect)
    {
        this.specialCharacter = specialCharacter;
        this.effect = effect;
    }
}