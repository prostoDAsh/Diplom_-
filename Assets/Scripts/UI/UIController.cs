using System;
using Signals.Buttons;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    public enum PanelType
    {
        None,
        Menu,
        Game,
        Win,
        Fail
    }

    private GameManager _gameManager;
    private MenuPanel _menuPanel;
    private GamePanel _gamePanel;
    private WinPanel _winPanel;
    private FailPanel _failPanel;
    
    private SignalBus _signalBus;

    [Inject]
    public void Construct(GameManager gameManager, SignalBus signalBus)
    {
        _gameManager = gameManager;
        _signalBus = signalBus;
    }

    private void Awake()
    {
        SetPanel(PanelType.Menu);
    }

    private void Start()
    {
        _signalBus.Subscribe<StartGameSignal>(OnStartGame);   
    }

    private void OnStartGame()
    {
        SetPanel(PanelType.Game);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<StartGameSignal>(OnStartGame); 
    }

    private void SetPanel(PanelType panelType)
    {
        _failPanel.gameObject.SetActive(panelType == PanelType.Fail);
        _gamePanel.gameObject.SetActive(panelType == PanelType.Game);
        _menuPanel.gameObject.SetActive(panelType == PanelType.Menu);
    }
}
