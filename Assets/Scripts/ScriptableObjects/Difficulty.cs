using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Difficulty", menuName = "GameDifficulty")]
public class Difficulty : ScriptableObject
{
    public List<float> platformGenerationRates;
    public float mineGenerationRate;

}
