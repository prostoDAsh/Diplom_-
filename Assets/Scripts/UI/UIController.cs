using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public enum Panel
    {
        None,
        Menu,
        Game,
        Win,
        Fail
    }

    private GameManager _gameManager;
    public static UIController Instance { get; private set; }
    private MenuPanel _menuPanel;
    private GamePanel _gamePanel;
    private WinPanel _winPanel;
    private FailPanel _failPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _menuPanel = GetComponentInChildren<MenuPanel>();
        _gamePanel = GetComponentInChildren<GamePanel>();
        _winPanel = GetComponentInChildren<WinPanel>();
        _failPanel = GetComponentInChildren<FailPanel>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        
    }
}
