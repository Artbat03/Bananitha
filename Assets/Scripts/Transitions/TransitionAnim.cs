using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnim : MonoBehaviour
{
    /// <summary>
    /// Method for deactivating the transition gameObject and passing to the next scene
    /// </summary>
    public void DeactivateTransitionAnimation()
    {
        if (!UIManager.instance.winPnl.activeSelf)
        {
            GameManager.instance.ChangeScene();
        }

        StartCoroutine(Coroutine_NextLevel());

        AudioManager.instance.StopSound();

        GameManager.instance.transitionGO.SetActive(false);

        /*if (UIManager.instance.winPnl.activeSelf)
        {
            AudioManager.instance.StopSound();

            GameManager.instance.transitionGO.SetActive(false);
        }*/
    }
    
    /// <summary>
    /// Coroutine for loading next scene
    /// </summary>
    /// <returns></returns>
    public IEnumerator Coroutine_NextLevel()
    {
        yield return new WaitForSeconds(10f);
    }
}
