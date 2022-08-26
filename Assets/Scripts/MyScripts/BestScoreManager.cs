using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager Instance;

    public string ScoreName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
