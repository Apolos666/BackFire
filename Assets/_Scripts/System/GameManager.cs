using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Initialization Variables
    
    private StateMachine _stateMachine;
    
    // States
    private MainMenuState _mainMenuState;
    private SelectionMenuState _selectionMenuState;
    private UpgradeMenuState _upgradeMenuState;
    private UnlockMenuState _unlockMenuState;
    private MapSelectionState _mapSelectionState;
    private StartGameState _startGameState;
    private GamePlayState _gamePlayState;
    private DeathState _deathState;
    private PauseMenuState _pauseMenuState;
    private SettingMenuState _settingMenuState;
    private DeathMenuState _deathMenuState;
    
    #endregion

    #region Listening on channels

    [Header("Listening on GUI channels")] 
    [SerializeField] private GUIEventChannelSO _mainMenu;
    [SerializeField] private GUIEventChannelSO _settingMenu;
    [SerializeField] private GUIEventChannelSO _selectionMenu;
    [SerializeField] private GUIEventChannelSO _upgradeMenu;
    [SerializeField] private GUIEventChannelSO _unlockMenu;
    [SerializeField] private GUIEventChannelSO _mapSelectionMenu;

    [Header("Listening on void channels")] 
    [SerializeField] private VoidEventChannelSO _turnBackRequest;
    
    #endregion
    
    #region Scene Transition conditions

    private bool _isMainMenu, _isSettingMenu, _isSelectionMenu, _isUpgradeMenu, _isUnlockMenu, _isMapSelectionMenu,
        _isStartGame, _isPauseMenu, _isDeathMenu = false;
    
    public bool IsMainMenu => _isMainMenu;
    public bool IsSettingMenu => _isSelectionMenu;
    public bool IsSelectionMenu => _isSelectionMenu;
    public bool IsUnlockMenu => _isUnlockMenu;
    public bool IsUpgradeMenu => _isUpgradeMenu;
    public bool IsMapSelectionMenu => _isMapSelectionMenu;
    public bool IsStartGame => _isStartGame;
    public bool IsPauseMenu => _isPauseMenu;
    public bool IsDeathMenu => _isDeathMenu;

    #endregion
    

    private void Awake()
    {
        #region Instantiating classes

        _stateMachine = new StateMachine();

        _mainMenuState = new MainMenuState();
        _selectionMenuState = new SelectionMenuState();
        _upgradeMenuState = new UpgradeMenuState();
        _unlockMenuState = new UnlockMenuState();
        _mapSelectionState = new MapSelectionState();
        _startGameState = new StartGameState();
        _gamePlayState = new GamePlayState();
        _deathState = new DeathState();
        _pauseMenuState = new PauseMenuState();
        _settingMenuState = new SettingMenuState();
        _deathMenuState = new DeathMenuState();

        #endregion
    }

    private void Start()
    {
        #region Add Transition

        At(_mainMenuState, _selectionMenuState, () => _isSelectionMenu);
        At(_mainMenuState, _settingMenuState, () => _isSettingMenu);
        
        At(_settingMenuState, _mainMenuState, () => _isMainMenu);
        At(_settingMenuState, _selectionMenuState, () => _isSelectionMenu);
        At(_settingMenuState, _upgradeMenuState, () => _isUpgradeMenu);
        At(_settingMenuState, _unlockMenuState, () => _isUnlockMenu);
        At(_settingMenuState, _mapSelectionState, () => _isMapSelectionMenu);
        At(_settingMenuState, _pauseMenuState, () => _isPauseMenu);
        At(_settingMenuState, _deathMenuState, () => _isDeathMenu);

        At(_selectionMenuState, _mainMenuState, () => _isMainMenu);
        At(_selectionMenuState, _upgradeMenuState, () => _isUpgradeMenu);
        At(_selectionMenuState, _unlockMenuState, () => _isUnlockMenu);
        At(_selectionMenuState, _mapSelectionState, () => _isMapSelectionMenu);
        At(_selectionMenuState, _settingMenuState, () => _isSettingMenu);
        
        At(_upgradeMenuState, _selectionMenuState, () => _isSelectionMenu);
        At(_upgradeMenuState, _mainMenuState, () => _isMainMenu);
        At(_upgradeMenuState, _unlockMenuState, () => _isUnlockMenu);
        At(_upgradeMenuState, _settingMenuState, () => _isSettingMenu);
        
        At(_unlockMenuState, _selectionMenuState, () => _isSelectionMenu);
        At(_unlockMenuState, _mainMenuState, () => _isMainMenu);
        At(_unlockMenuState, _upgradeMenuState, () => _isUpgradeMenu);
        At(_unlockMenuState, _settingMenuState, () => _isSettingMenu);
        
        At(_mapSelectionState, _startGameState, () => _isStartGame);
        At(_mapSelectionState, _settingMenuState, () => _isSettingMenu);
        At(_mapSelectionState, _selectionMenuState, () => _isSelectionMenu);

        #endregion
        
        _stateMachine.SetState(_mainMenuState);
        
        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
    }

    private void OnEnable()
    {
        #region Listening requests

        _mainMenu.OnGUIChangedRequest += (changedRequest) =>
        {
            _isSelectionMenu = false;
            _isUpgradeMenu = false;
            _isUnlockMenu = false;
            _isSettingMenu = false;
            _isMainMenu = changedRequest;
        };

        _turnBackRequest.OnChangedRequest += () =>
        {
            _isSettingMenu = false;
            switch (_stateMachine.PreviousState)
            {
                case MainMenuState:
                    _isMainMenu = true;
                    break;
                case SelectionMenuState:
                    _isSelectionMenu = true;
                    break;
                case UpgradeMenuState:
                    _isUpgradeMenu = true;
                    break;
                case UnlockMenuState:
                    _isUnlockMenu = true;
                    break;
                case MapSelectionState:
                    _isMapSelectionMenu = true;
                    break;
                case PauseMenuState:
                    _isPauseMenu = true;
                    break;
                case DeathState:
                    _isDeathMenu = true;
                    break;
                default:
                    break;
            }
        };

        _settingMenu.OnGUIChangedRequest += (changedRequest) =>
        {
            _isMainMenu = false;
            _isSelectionMenu = false;
            _isUpgradeMenu = false;
            _isUnlockMenu = false;
            _isMapSelectionMenu = false;
            _isPauseMenu = false;
            _isDeathMenu = false;
            _isSettingMenu = changedRequest;
        };

        _selectionMenu.OnGUIChangedRequest += (changedRequest) => { 
            _isMainMenu = false;
            _isUpgradeMenu = false;
            _isUnlockMenu = false;
            _isMapSelectionMenu = false;
            _isSettingMenu = false; 
            _isSelectionMenu = changedRequest; 
        };
        
        _unlockMenu.OnGUIChangedRequest += (changedRequest) => {
            _isSelectionMenu = false;
            _isMainMenu = false;
            _isUpgradeMenu = false;
            _isSelectionMenu = false;
            _isUnlockMenu = changedRequest;
        };
        
        _upgradeMenu.OnGUIChangedRequest += (changedRequest) =>
        {
            _isSelectionMenu = false;
            _isMainMenu = false;
            _isUnlockMenu = false;
            _isSelectionMenu = false;
            _isUpgradeMenu = changedRequest;
        };

        _mapSelectionMenu.OnGUIChangedRequest += (changedRequest) =>
        {
            _isSelectionMenu = false;
            _isSettingMenu = false;
            _isStartGame = false;
            _isMapSelectionMenu = changedRequest;
        };
        
        #endregion

    }

    private void Update()
    {
        _stateMachine.Tick();
        print($"Previous State: {_stateMachine.PreviousState}");
    }
}
