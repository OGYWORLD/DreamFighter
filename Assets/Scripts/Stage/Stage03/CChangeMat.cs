using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿À°¡À»
#endregion
public class CChangeMat : MonoBehaviour
{
    public Texture[] textures;

    private void OnEnable()
    {
        int random = Random.Range(0, textures.Length - 1);

        Material mat = gameObject.GetComponent<Renderer>().material;

        mat.mainTexture = textures[random];
    }
}
