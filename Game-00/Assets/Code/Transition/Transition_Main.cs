using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_Main : MonoBehaviour
{

    [SerializeField] private List<Transition> transition_Starting_;
    [SerializeField] private List<Transition> transition_Ending_;
    [SerializeField] private TransitionPair currTransition_;

    public static Transition_Main instance_;

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, true);
    }
    public TransitionPair GetCurrTransition()
    {
        return currTransition_;
    }
    public List<Transition> GetTransitionStart()
    {
        return transition_Starting_;
    }
    public Transition GetTransitionStart(int index)
    {
        if (GENERIC.IsValidIndex(transition_Starting_, index))
            return transition_Starting_[index];
        else
            return null;
    }
    public List<Transition> GetTransitionEnding()
    {
        return transition_Ending_;
    }
    public Transition GetTransitionEnding(int index)
    {
        if (GENERIC.IsValidIndex(transition_Ending_, index))
            return transition_Ending_[index];
        else
            return null;
    }
}
