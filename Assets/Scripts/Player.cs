using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;

    private void Start()
    {
        characterStats = new CharacterStats(10, 10, 10);
    }
}
