using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region 우인혜
#endregion


/// <summary>
/// 카메라를 여럿 다루는 경우 등등에 활용할 수 있을 듯...
/// 필요한 경우 특정한 매니저를 만드는 것도.
/// </summary>
[Serializable]
public class TransitionValue
{
    /// <summary>
    /// 기준점이 될 만한 이름
    /// </summary>
    public string name;

    /// <summary>
    /// 위치 보간 또는 움직임에 사용할 속도
    /// </summary>
    public float MovePosSpeed;

    /// <summary>
    /// 각도 보간 또는 움직임에 사용할 속도
    /// </summary>
    public float MoveRotationSpeed;

    /// <summary>
    /// 초기화용 <seealso cref="Transform.position"/> 또는 위치 보간의 시작점
    /// </summary>
    public Vector3 startPosition;

    /// <summary>
    /// 초기화용 <seealso cref="Transform.rotation"/> 또는 각도 보간의 시작점
    /// </summary>
    public Quaternion startRotation;


    /// <summary>
    ///  위치 보간의 끝점
    /// </summary>
    public Vector3 endPosition;

    /// <summary>
    ///  각도 보간의 끝점
    /// </summary>
    public Quaternion endRotation;

    /// <summary>
    /// 특정 <seealso cref="Transform"/>을 바라볼 타겟으로 삼는 경우 활용
    /// </summary>
    public Transform target;
}