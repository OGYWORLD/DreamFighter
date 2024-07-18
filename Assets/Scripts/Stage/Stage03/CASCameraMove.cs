using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿À°¡À»
#endregion

public class CASCameraMove : CCameraMove
{
    protected sealed override void Start()
    {
        StageManager.instance.betweenDis = 58f;

        base.Start();
    }

    protected sealed override void Update()
    {
        if (isIntroEnd)
        {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }
    }
}
