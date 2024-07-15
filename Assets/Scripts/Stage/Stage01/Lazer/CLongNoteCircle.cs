using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 롱 노트의 사라질 때의 타이밍을 나타내는 원형 아이콘을 동작시키는 스크립트 입니다.
/// </summary>

public class CLongNoteCircle : MonoBehaviour
{
    public Transform circle; // 원 아이콘

    public Vector3 targetSize; // 줄어들었을 때의 사이즈
    public Vector3 initialSize; // 원의 초기 사이즈

    public CLazerSetActive lazerSet;

    private void OnEnable()
    {
        StartCoroutine(CircleSet());
    }

    IEnumerator CircleSet()
    {
        // OnEnable이 Start 함수 이전에 호출되므로 CLazerSetActive에서 변수가 할당되기 전에 참조하기 때문에 null을 방지하기 위해 한 프레임 이후 코루틴 실행
        yield return new WaitForEndOfFrame();

        float sumTime = 0f;

        float duringTime = StageManager.instance.noteMoveSpeed +
            StageManager.instance.notes[lazerSet.noteIdx].endTime - StageManager.instance.notes[lazerSet.noteIdx].srtTime;

        while (sumTime <= duringTime)
        {
            float t = sumTime / duringTime;
            circle.localScale = Vector3.Lerp(initialSize, targetSize, t);

            sumTime += Time.deltaTime;
            yield return null;
        }

        yield break;
    }
}
