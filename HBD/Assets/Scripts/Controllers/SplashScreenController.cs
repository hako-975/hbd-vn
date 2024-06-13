using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenController : MonoBehaviour
{
    [SerializeField]
    private Image tapToStart;

    [SerializeField]
    private GameObject tapToStartButton;

    private void Awake()
    {
        tapToStart.raycastTarget = false;
    }

    private void Start()
    {
        StartCoroutine(WaitAnim());
    }
    
    public void TapToStartButton()
    {
        StartCoroutine(WaitSound());
    }

    private IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(1f);
        tapToStart.GetComponent<Animator>().SetTrigger("White Screen");
        yield return new WaitForSeconds(1f);
        tapToStartButton.GetComponent<Animator>().SetTrigger("Tap To Start Fade");
        tapToStart.raycastTarget = true;
    }

    private IEnumerator WaitSound()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerPrefsController.instance.SetNextScene("MainMenu");
    }
}
