using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();

    public GameObject enemyPrefab;
    public GameObject enemyHpBarPrefab;
    public Canvas canvas;
    public float delay = 0.5f;

    private int spawnMinPosX = -8;
    private int spawnMaxPosX = 8;
    private int spawnPosY = 5;

    Vector3 spawnPosition;

    public Coroutine Co_EnemySpawn;

    private void Start() {
        
        Co_EnemySpawn = StartCoroutine(EnemySpawn());
    }

    public IEnumerator EnemySpawn(){

        while(true){

            if(enemyList.Count < 5){

                Debug.Log("적 생성");

                spawnPosition = new Vector3(Random.Range(spawnMinPosX, spawnMaxPosX + 1), spawnPosY);

                Enemy enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity).GetComponent<Enemy>();
                enemyList.Add(enemy.gameObject);
                GameObject hpBar = Instantiate(enemyHpBarPrefab, spawnPosition, Quaternion.identity);

                hpBar.transform.parent = canvas.transform;
                hpBar.GetComponent<EnemyHpSlider>().enemyInfo = enemy;


            }


            if(enemyList.Count == 0){

                enemyList.Add(Instantiate(enemyPrefab, spawnPosition, Quaternion.identity));
                Instantiate(enemyHpBarPrefab, spawnPosition,Quaternion.identity);
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
