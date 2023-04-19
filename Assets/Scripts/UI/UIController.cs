using System;
using Enums;
using Signals.Buttons;
using Signals.Keys;
using UI.Panels;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    private MenuPanel _menuPanel;
    private GamePanel _gamePanel;
    private WinPanel _winPanel;
    private FailPanel _failPanel;
    private StopPanel _stopPanel;
    
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus, MenuPanel menuPanel, 
        GamePanel gamePanel, WinPanel winPanel, FailPanel failPanel, StopPanel stopPanel)
    {
        _signalBus = signalBus;
        _failPanel = failPanel;
        _gamePanel = gamePanel;
        _menuPanel = menuPanel;
        _winPanel = winPanel;
        _stopPanel = stopPanel;
    }

    private void Start()
    {
        ShowPanel(PanelType.Menu);
        _signalBus.Subscribe<StartGameSignal>(OnStartedGame);
        _signalBus.Subscribe<StopGameSignal>(OnStopGame);
        _signalBus.Subscribe<ReturnMenuSignal>(OnReturnMenu);
        _signalBus.Subscribe<ContinueGameSignal>(OnStartedGame);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // todo просто пример (P/s будет ошибка из-за большого колличесва вызова Fire)
        {
            _signalBus.Fire<StopGameSignal>();
        }
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<StartGameSignal>(OnStartedGame);
        _signalBus.Unsubscribe<StopGameSignal>(OnStopGame);
        _signalBus.Unsubscribe<ReturnMenuSignal>(OnReturnMenu);
        _signalBus.Unsubscribe<ContinueGameSignal>(OnStartedGame);
    }

    private void ShowPanel(PanelType panelType)
    {
        _menuPanel.gameObject.SetActive(panelType == PanelType.Menu);
        _gamePanel.gameObject.SetActive(panelType == PanelType.Game);
        _winPanel.gameObject.SetActive(panelType == PanelType.Win);
        _failPanel.gameObject.SetActive(panelType == PanelType.Fail);
        _stopPanel.gameObject.SetActive(panelType == PanelType.Stop);
    }
    
    private void OnStartedGame()
    {
        ShowPanel(PanelType.Game);
    }
    
    private void OnStopGame()
    {
        ShowPanel(PanelType.Stop);
    }
    
    private void OnReturnMenu()
    {
        ShowPanel(PanelType.Menu);
    }
}
