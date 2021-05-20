
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class UIManager : MonoBehaviour
{
    public GameEvents events = null;
    [SerializeField] Text _enemycountTxt;
    [SerializeField] SpawnManagerScriptableObject spawnScriptable;

    [Header("countdown Vars")]
    [SerializeField] Text CountDowntxt = default;
    [SerializeField] RectTransform Panel = default;
    float timer;
    float TimeInterval;

    [Header("GameStatus")]
    [SerializeField] RectTransform gameoverPanel = default;
    [SerializeField] RectTransform winPanel=default;

    [Header("save")]
    [SerializeField] Text ShootinCountertxt;
    [SerializeField] NewSave _newSave;
    private void Awake()
    {
      if (File.Exists(Application.persistentDataPath+"/save.txt"))
      {         
          _newSave.Load();
          ShootinCountertxt.text = "Total Shhoting For now : " + ShootingManager.ShootingCounter.ToString();
      }
       
    }
    private void OnEnable()
    {
        events.EnemyCountUpdate += UpdateEnemyCount;
        events.updateGameStatusWin += UpdateGameStatuswin;
        events.updateGameStatusLose += UpdateGameStatuslose;
        events.updateShooterCount += UpdateShooterCount;
    }
    private void OnDisable()
    {
        events.EnemyCountUpdate -= UpdateEnemyCount;
        events.updateGameStatusWin -= UpdateGameStatuswin;
        events.updateGameStatusWin -= UpdateGameStatuslose;
        events.updateShooterCount -= UpdateShooterCount;
    }
    private void Start()
    {
        UpdateEnemyCount();
        timer = 2;  
      
    }
    private void Update()
    {       
        timer -= Time.deltaTime;
        CountDowntxt.text = timer.ToString("0");      
              
        if (timer <= 0)
        {
            Panel.gameObject.SetActive(false);
        }
    }

    public void UpdateShooterCount()
    {
        ShootinCountertxt.text = "Total Shooting For now : " + ShootingManager.ShootingCounter.ToString();
    }
    public void UpdateEnemyCount()
    {
        _enemycountTxt.text = "Enemy: " + GetComponent<Spawner>().TotalEnemy.ToString();
    }
    public void UpdateGameStatuswin()
    {
        StartCoroutine(WinPanel());
    }
    public void UpdateGameStatuslose()
    {
        StartCoroutine(GameoverPanel());
    }

      IEnumerator GameoverPanel()
      {
          yield return new WaitForSeconds(2);
        gameoverPanel.gameObject.SetActive(true);
    
      }
     IEnumerator WinPanel()
     {
        yield return new WaitForSeconds(2);
        winPanel.gameObject.SetActive(true);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
