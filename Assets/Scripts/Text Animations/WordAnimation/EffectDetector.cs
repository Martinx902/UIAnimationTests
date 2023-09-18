using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Effect Detector"))]
public class EffectDetector : ScriptableObject
{
    [SerializeField]
    public List<Effect> effects;

    private void Awake()
    {
        if (effects == null)
            effects = new List<Effect>();
    }
}

[System.Serializable]
public class Effect
{
    public char specialCharacter;
    public EffectTypes effect;
}

public enum EffectTypes
{
    Test,
    None
}