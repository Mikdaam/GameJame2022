using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public enum GAMESTATE
{
    menu,
    play,
    pause,
    victory,
    gameover
}
public class GameManager : MonoBehaviour
{
    // ====== SINGLETON (instance unique) ======
    private static GameManager m_Instance;
    public static GameManager Instange { get { return m_Instance; } }

    int m_Score;
    [SerializeField] int m_VictoryScore;

    GAMESTATE m_State;

    public bool IsPlaying { get { return m_State == GAMESTATE.play; } }
    void SetState(GAMESTATE newState)
    {
        m_State = newState;
        switch (m_State)
        {
            case GAMESTATE.menu:
                EventManager.Instance.Raise(new GameMenuEvent());
                break;
            case GAMESTATE.play:
                EventManager.Instance.Raise(new GamePlayEvent());
                break;
            case GAMESTATE.pause:
                EventManager.Instance.Raise(new GamePauseEvent());
                break;
            case GAMESTATE.victory:
                EventManager.Instance.Raise(new GameVictoryEvent());
                break;
            case GAMESTATE.gameover:
                EventManager.Instance.Raise(new GameOverEvent());
                break;
            default:
                break;
        }
    }
    private void Awake()
    {
        //Vérifie s'il y a un GameManager actif
        if (!m_Instance) m_Instance = this;
        //S'il y a plusieurs GameManager, on les détruits jusqu'à ce qu'il n'en reste plus QU'UN.
        else Destroy(this.gameObject);
    }
    //Listeners for play button
    private void OnEnable()
    {
        EventManager.Instance.AddListener<PlayButtonClickedEvent>(PlayButtonClickedEventCallback);
    }
    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<PlayButtonClickedEvent>(PlayButtonClickedEventCallback);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetState(GAMESTATE.menu);
    }

    // Update is called once per frame
    void Update()
    {

    }
    #region Events callbacks
    void PlayButtonClickedEventCallback(PlayButtonClickedEvent e)
    {
        SetState(GAMESTATE.play);
    }
    #endregion
}
