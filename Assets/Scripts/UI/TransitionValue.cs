using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region ������
#endregion


/// <summary>
/// ī�޶� ���� �ٷ�� ��� �� Ȱ���� �� ���� ��...
/// �ʿ��� ��� Ư���� �Ŵ����� ����� �͵�.
/// </summary>
[Serializable]
public class TransitionValue
{
    /// <summary>
    /// �������� �� ���� �̸�
    /// </summary>
    public string name;

    /// <summary>
    /// ��ġ ���� �Ǵ� �����ӿ� ����� �ӵ�
    /// </summary>
    public float MovePosSpeed;

    /// <summary>
    /// ���� ���� �Ǵ� �����ӿ� ����� �ӵ�
    /// </summary>
    public float MoveRotationSpeed;

    /// <summary>
    /// �ʱ�ȭ�� <seealso cref="Transform.position"/> �Ǵ� ��ġ ������ ������
    /// </summary>
    public Vector3 startPosition;

    /// <summary>
    /// �ʱ�ȭ�� <seealso cref="Transform.rotation"/> �Ǵ� ���� ������ ������
    /// </summary>
    public Quaternion startRotation;


    /// <summary>
    ///  ��ġ ������ ����
    /// </summary>
    public Vector3 endPosition;

    /// <summary>
    ///  ���� ������ ����
    /// </summary>
    public Quaternion endRotation;

    /// <summary>
    /// Ư�� <seealso cref="Transform"/>�� �ٶ� Ÿ������ ��� ��� Ȱ��
    /// </summary>
    public Transform target;
}