using UnityEngine;
using UnityEngine.UI;

public class SetTimeScale : MonoBehaviour
{
	float value = 1.2f;

	private void OnEnable ( )
		=> Time.timeScale = value;
}
