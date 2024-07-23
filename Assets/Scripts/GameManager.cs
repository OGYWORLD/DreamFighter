using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿À°¡À»
#endregion

public class GameManager : MonoBehaviour
{
    public class ScoreRecord
    {
        public int maxScore { get; set; }
        public int maxCombo { get; set; }
        public int maxRank { get; set; } // 0: S, 1: A, 2: B, 3: C
    }

    public static GameManager instance { get; private set; }

    public float beatPadding { get; set; } = 0f;

    public List<bool> isCutSceneOpen = new List<bool>();

    public List<ScoreRecord> scoreRecords = new List<ScoreRecord>();

    private int cutSceneNum = 8;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // CutScene Open Init
        isCutSceneOpen.Add(true); // intro
        for (int i = 1; i < cutSceneNum; i++)
        {
            isCutSceneOpen.Add(false);
        }

        scoreRecords.Add(new ScoreRecord { maxCombo = 0, maxRank = 0, maxScore = 0 });
    }
}
