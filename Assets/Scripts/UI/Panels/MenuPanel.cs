using System;
using UI.Buttons;
using UnityEngine;
using Zenject;

public class MenuPanel : MonoBehaviour
{
    private StartGameButton _startGameButton;
    private ContinueGameButton _continueGameButton;
    private StartNewGameButton _startNewGameButton;
    
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void Awake()
    {
        _startGameButton = GetComponentInChildren<StartGameButton>(true);
        _continueGameButton = GetComponentInChildren<ContinueGameButton>(true);
        _startNewGameButton = GetComponentInChildren<StartNewGameButton>(true);
    }

    private void OnEnable()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}
