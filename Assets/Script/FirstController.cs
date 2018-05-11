using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

    private List<GameObject> patrols;
    private GameObject player;
    private float rotateSpeed = 150f;
    private float playerSpeed = 2f;
    public PatrolActionManager actionManager;
    private GameStatus curStatus;
    public ScoreRecorder scoreManager;

    void Awake()
    {
        SSDirector director = SSDirector.getInstance();
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
        gameObject.AddComponent<PatrolActionManager>();

        actionManager = gameObject.GetComponent<PatrolActionManager>();

        scoreManager = Singleton<ScoreRecorder>.Instance;

        curStatus = GameStatus.Ready;
    }
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        Debug.Log(curStatus);
	}
    //实现接口函数中的资源加载
    //导演需要资源加载，但是具体加载什么资源放给了场景控制器
    public void LoadResources()
    {
        player = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/player"),
                                                        new Vector3(-2,1,-1), Quaternion.identity);
        PropFactory myFactory = Singleton<PropFactory>.Instance;
        patrols = myFactory.GetPatrols();
        actionManager = gameObject.GetComponent<PatrolActionManager>();

        Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/floor 1"), Vector3.zero, Quaternion.identity);
        for (int i = 0; i < patrols.Count; i++)
        {
            actionManager.PatrolRoundStart(patrols[i]);
        }
        Debug.Log("loaded resouse done");
    }
    //实现接口函数中的游戏结束
    public void GameOver()
    {
        Debug.Log("game over");
        curStatus = GameStatus.Over;
    }
    //实现接口函数中游戏开始
    public void StartGame()
    {
        Debug.Log("Start game");
        curStatus = GameStatus.Running;

    }
    public int GetScore()
    {
        return scoreManager.GetScore();
    }
    public void MovePlayer(float translationX, float translationZ)
    {
        if (curStatus == GameStatus.Running)
        {
            if (translationX != 0 || translationZ != 0)
            {
                player.GetComponent<Animator>().SetBool("Run", true);
            }
            else
            {
                player.GetComponent<Animator>().SetBool("Run", false);
            }
            Debug.Log("X : " + translationX);
            player.transform.Translate(0, 0, translationZ * playerSpeed * Time.deltaTime);
            player.transform.Rotate(0, translationX * rotateSpeed * Time.deltaTime, 0);
        }
    }
    public GameStatus GetStatus()
    {
        return curStatus;
    }
    public void SetStatus(GameStatus _status)
    {
        curStatus = _status;
    }

}
