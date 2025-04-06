using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject npc;
    [HideInInspector] public ColorChanger[] objs;
    [HideInInspector]  public TilemapChanger[] tileObjs;
    [HideInInspector]  public TextColorChanger textObj;
    public Vector3 checkpointPos;
    public Text cutText;
    public Animator cutscene;
    public PlayerController player;
    public static GameManager instance;
    public GameObject mainText;
    public bool hasQuestItem = false;
    private void Awake()
    {
        FindObjectsSortMode m = FindObjectsSortMode.None;
        objs = FindObjectsByType<ColorChanger>(m);
        tileObjs = FindObjectsByType<TilemapChanger>(m);
        textObj = FindAnyObjectByType<TextColorChanger>();
        instance = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("flower")) Destroy(npc);
        if(!PlayerPrefs.HasKey("checkpointX"))
        {
            PlayerPrefs.SetFloat("checkpointX", player.transform.position.x);
            PlayerPrefs.SetFloat("checkpointY", player.transform.position.y);
        }
    }

    public void UpdateObjs()
    {
        FindObjectsSortMode m = FindObjectsSortMode.None;
        objs = FindObjectsByType<ColorChanger>(m);
    }

    public void StartEnd()
    {
        cutscene.SetTrigger("End");
    }
}
