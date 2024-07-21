using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿À°¡À»
#endregion

public class CASCameraMove : CCameraMove
{
    protected sealed override void Start()
    {
        StageManager.instance.betweenDis = 48f;

        base.Start();
    }

    protected sealed override void Update()
    {
        if (isIntroEnd)
        {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }
    }

    protected sealed override IEnumerator WaitIntro()
    {
        yield return new WaitForSeconds(4f);

        isIntroEnd = true;
    }
}
