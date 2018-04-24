using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoundController : MonoBehaviour, ISceneController, IUserAction {
    public Queue<GameObject> disks = new Queue<GameObject>();

    public int diskCount = 10;

    private int roundCount;

    public int totalRound = 3;

    private float internalTime;

    private ActionMode mode;

    public GameState currentState = GameState.START; 
    public IActionManager actionManager { get; set; }// actionManager 在ccactionmanager start函数中被赋值
    
    //the first script
    private void Awake()
    {
        Director director = Director.getInstance();
        director.currentSceneController = this;
        director.currentSceneController.LoadResource();

        this.gameObject.AddComponent<ScoreRecorder>();
        currentState = GameState.START;
        roundCount = 0;

        mode = ActionMode.NOTSET;
    }

    // 检测每一帧的游戏状态并控制游戏态变化
    void Update()
    {
        //Debug.Log(currentState);
        if(currentState == GameState.START)
        {
            this.Reset();
        }
        else if(currentState == GameState.ROUND_START)
        {
            roundCount++;
            actionManager.setDiskNumber(10);
            currentState = GameState.RUNNING;
            NextRound();
        }
        else if(actionManager.getDiskNumber() == 0 && currentState == GameState.RUNNING)
        {
            if (roundCount == 3)
            {
                currentState = GameState.END;
                roundCount = 0;
            }
            else
            {
                currentState = GameState.ROUND_END;
            }
        }
        else if(currentState == GameState.RUNNING && actionManager.getDiskNumber() != 0)
        {
            if (internalTime >= 1)
            {
                ThrowDisk();
                internalTime = 0;
            }
            else internalTime += Time.deltaTime;
        }
    }

    private void ThrowDisk()
    {
        if (disks.Count == 0)
        {
            Debug.LogError("no disk in controller queue while " + actionManager.getDiskNumber());
            return;
        }
        GameObject temp = disks.Dequeue();
        temp.SetActive(true);
        actionManager.StartThrow(temp);
    }
    //开始新回合：根据游戏回合数从飞碟工厂获得飞碟并交给动作管理器
    public void NextRound()
    {
        Debug.Log("Next Round " + roundCount);
        DiskFactory df = Singleton<DiskFactory>.Instance;
        for (int i = 0; i < diskCount; i++)
        {
            GameObject d = df.getDisk(roundCount);
            disks.Enqueue(d);
        }
    }

    public void RecycleDisk(GameObject _usedDisk)
    {
        DiskFactory df = Singleton<DiskFactory>.Instance;
        df.freeDisk(_usedDisk);
    }

    private void Reset()
    {
        this.gameObject.GetComponent<ScoreRecorder>().Reset();
        currentState = GameState.START;
        roundCount = 0;
    }
    // interface ISceneController
    public void LoadResource()
    {

    }

    //#region_IUserAction_Interface
    public int GetScore()
    {
        return this.gameObject.GetComponent<ScoreRecorder>().getScore();
    }
    public GameState GetGameState()
    {
        return currentState;
    }
    public void SetGameState(GameState _gameState)
    {
        currentState = _gameState;
        Debug.Log("current state : " + currentState);
    }
    public void hit(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        RaycastHit[] hits = Physics.RaycastAll(ray);
        for(int i = 0; i < hits.Length;i++)
        {
            Debug.Log(hits.Length);
            RaycastHit hit = hits[i];
            if(hit.collider.gameObject.GetComponent<DiskData>() != null)
            {
                this.gameObject.GetComponent<ScoreRecorder>().Record(hit.collider.gameObject.GetComponent<DiskData>());
                hit.collider.gameObject.GetComponent<Renderer>().enabled = false;
            }
        }
    }
    //#end IUAction
    public void setMode(ActionMode m)
    {
        mode = m;
        if (m == ActionMode.KINEMATIC)
        {
            this.gameObject.AddComponent<CCActionManager>();
        }
        else
        {
            this.gameObject.AddComponent<PhysicActionManager>();
        }
    }
    public ActionMode getMode()
    {
        return mode;
    }
}
