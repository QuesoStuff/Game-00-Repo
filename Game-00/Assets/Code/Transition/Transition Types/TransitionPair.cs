using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransitionPair : MonoBehaviour
{
    [SerializeField]
    public Transition startTransition_;

    [SerializeField]
    public Transition endTransition_;

    public void StartTransition()
    {
        startTransition_.BeginTransition();
    }
    public IEnumerator StartCoroutine()
    {
        yield return startTransition_.TransitionCoroutine();
    }
    public void EndTransition()
    {
        StartCoroutine(EndCoroutine());
    }
    public IEnumerator EndCoroutine()
    {
        yield return endTransition_.TransitionCoroutine();
        endTransition_.Visible(false);
    }

}
