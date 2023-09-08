using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

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

    [FormerlySerializedAs("_SelectionMenu")]
    [Header("Listening on channels")] 
    [SerializeField] private GUIEventChannelSO _selectionMenu;

    #endregion
    
    #region Scene Transition conditions

    private bool _isSelectionMenu = false;
    public bool IsSelectionMenu => _isSelectionMenu;

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

        At(_mainMenuState, _selectionMenuState, () => _isSelectionMenu == true);

        #endregion
        
        _stateMachine.SetState(_mainMenuState);
        
        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
    }

    private void OnEnable()
    {
        #region Listening requests

        _selectionMenu.OnGUIChangedRequest += (changedRequest) => _isSelectionMenu = changedRequest;;

        #endregion
        
    }

    private void Update() => _stateMachine.Tick();
}
