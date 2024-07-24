using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#region ±Ë«œ¿∫
#endregion

public class GuessDreamControl : MonoBehaviour
{
    public Image Black;
    public Image White;
    public GameObject You;
    public GameObject Torso;
    public ParticleSystem Particle;

    private void Start()
    {
        FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 2f);
        Invoke("ICanBeYou", 14f);
        Invoke("Effect", 24.7f);
        Invoke("DisappearToo", 25f);
        Invoke("DidyouRecognize", 29f);
        Invoke("IamtheDREAM", 34f);
        Invoke("GuessWho", 40f);
    }

    void ICanBeYou()
    {
        You.SetActive(true);
    }

    void Effect()
    {
        Particle.Play();
    }

    void DisappearToo()
    {
        You.SetActive(false);
        Torso.SetActive(false);
    }

    void DidyouRecognize()
    {
        Torso.SetActive(true);
    }

    void IamtheDREAM()
    {
        FadeControl.Instance.StartFadeOut(White, 0f, 1f, 3f);
    }

    void GuessWho()
    {
        SceneManager.LoadScene("Day 1");
    }
}