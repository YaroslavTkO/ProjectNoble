using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Database", menuName = "DifficultyDatabase")]
public class DifficultyDatabase : ScriptableObject
{
    public List<Difficulty> difficulties;
    public List<int> scoresMilestones;
}
