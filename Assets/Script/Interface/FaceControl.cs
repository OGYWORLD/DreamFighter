using System.Collections;
using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class FaceControl : MonoBehaviour
{
    private static FaceControl _instance;

    public static FaceControl Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("FaceControl");
                _instance = obj.AddComponent<FaceControl>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public Coroutine StartFaceControl(SkinnedMeshRenderer SMR, string Name, float StartWeight, float EndWeight, float Duration)
    {
        return StartCoroutine(FaceController(SMR, Name, StartWeight, EndWeight, Duration));
    }

    private IEnumerator FaceController(SkinnedMeshRenderer SMR, string Name, float StartWeight, float EndWeight, float Duration)
    {
        int Index = SMR.sharedMesh.GetBlendShapeIndex(Name);

        float ElapsedTime = 0f;

        while (ElapsedTime < Duration)
        {
            float CurrentWeight = Mathf.Lerp(StartWeight, EndWeight, ElapsedTime / Duration);
            SMR.SetBlendShapeWeight(Index, CurrentWeight);
            ElapsedTime += Time.deltaTime;
            yield return null;
        }

        SMR.SetBlendShapeWeight(Index, EndWeight);
    }
}