using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TDManager : MonoBehaviour
{
    private static TDManager _instance;
    public static TDManager Instance { get { return _instance; } }
    
    public List<GameObject> enemyPath;
    public GameObject spawnPoint;
    public Text moneyText;
    public Text healthText;
    public GameObject winScreen;
    public GameObject loseScreen;

    public GameObject StandardEnemy;
    public GameObject FastEnemy;
    public GameObject TankEnemy;

    public int playerMoney;
    public bool waveInProgress;
    public int playerHealth;
    public int enemyAlive;
    public int totalWaves;
    public int currentWave;
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        currentWave = 0;
        totalWaves = 8;
        waveInProgress = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyAlive == 0 && !waveInProgress)
        {
            nextWave();
        }
        if(playerHealth <= 0)
        {
            loseScreen.SetActive(true);
        }

        moneyText.text = "$" + playerMoney.ToString();
        healthText.text = playerHealth.ToString();
    }
    public void nextWave()
    {
        currentWave++;

        if(currentWave == 1)
        {
            StartCoroutine(Spawn(StandardEnemy, 1f, 15));
        }
        else if(currentWave == 2)
        {
            StartCoroutine(Spawn(StandardEnemy, 1f, 10));
            StartCoroutine(Spawn(FastEnemy, 1f, 5));
        }
        else if (currentWave == 3)
        {
            StartCoroutine(Spawn(TankEnemy, 2f, 3));
        }
        else if (currentWave == 4)
        {
            StartCoroutine(Spawn(FastEnemy, 0.3f, 20));
        }
        else if (currentWave == 5)
        {
            StartCoroutine(Spawn(StandardEnemy, 1f, 20));
            StartCoroutine(Spawn(FastEnemy, 1f, 10));
            StartCoroutine(Spawn(TankEnemy, 2f, 5));
        }
        else if(currentWave == 6)
        {
            winScreen.SetActive(true);
        }

        waveInProgress = true;
    }

    public void enemyThrough()
    {
        playerHealth--;
        enemyAlive--;
    }
    IEnumerator Spawn(GameObject enemyToSpawn, float delay, int enemyCount)
    {
        for(;enemyCount > 0; enemyCount--)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(enemyToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);
            enemyAlive++;
        }
    }

    
    public void enemyDeath(GameObject enemyType)
    {
        if(enemyType.GetComponent<StandardEnemy>())
        {
            playerMoney += 1;
        }
        else if(enemyType.GetComponent<FastEnemy>())
        {
            playerMoney += 2;
        }
        else if (enemyType.GetComponent<TankEnemy>())
        {
            playerMoney += 3;
        }

        enemyAlive--;

        if(enemyAlive == 0)
        {
            waveInProgress = false;
        }
    }

    public void resetGame()
    {
        SceneManager.LoadScene(0);
    }

        
}
