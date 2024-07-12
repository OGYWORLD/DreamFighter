using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

// todo: (인혜) 프로필 보간... 이걸 고쳐서 쓰거나 아니면 다른 방법을 찾거나

public class ProfileInterpolation : MonoBehaviour
{
    public PostProcessVolume volume;
    public PostProcessProfile blendProfile;

    public PostProcessProfile dayProfile;
    public PostProcessProfile nightProfile;
    
    public float blendSpeed = 1.0f;

    private bool isBlending = false;
    private float blendTime;



    void Start()
    {
        volume = FindObjectOfType<PostProcessVolume>();

        if(volume && dayProfile)
        {
            volume.profile = dayProfile;
        }
    }

    private void Update()
    {
        if(isBlending)
        {
            blendTime += Time.deltaTime * blendSpeed;
            float t = Mathf.Clamp01(blendTime);

            //BlendProfiles(dayProfile, nightProfile, t);
        }
    }

    void Blending()
    {
        
    }

    /*void BlendProfiles(PostProcessProfile fromProfile, PostProcessProfile toProfile, float t)
    {
        var settings1 = fromProfile.settings;
        var settings2 = toProfile.settings;

        for (int i = 0; i < settings1.Count; i++)
        {
            var setting1 = settings1[i];
            var setting2 = settings2[i];

            //var blendedSetting = setting1;
            //blendedSetting.Lerp(setting1, setting2, t);

            var blendedSetting = setting1;

            volume.profile.settings[i] = blendedSetting;
        }
    }*/

    public void StartBlend()
    {
        isBlending = true;
        blendTime = 0.0f;
    }

}
