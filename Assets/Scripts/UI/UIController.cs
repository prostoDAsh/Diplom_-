using System;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    private GameManager _gameManager;
    private MenuPanel _menuPanel;
    private GamePanel _gamePanel;
    private WinPanel _winPanel;
    private FailPanel _failPanel;
    
    [Inject]
    public void Construct()
    {
        
    }

    private void Start()
    {
        
    }
}
