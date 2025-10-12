using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterPrefab;
    
    private GameObject _spawnedMonster;
    
    [SerializeField] private Transform leftPos, rightPos;
    
    private int randomIndex;
    private int randomSide;
    
    void Awake()
    {
    }
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            
            randomIndex = Random.Range(0, monsterPrefab.Length);
            randomSide = Random.Range(0, 2);
            
            _spawnedMonster = Instantiate(monsterPrefab[randomIndex]);
            
            if (randomSide == 0)
            {
                _spawnedMonster.transform.position = leftPos.position;
                _spawnedMonster.GetComponent<Monster>().speed = Random.Range(5f, 10f);
            }
            else
            {
                _spawnedMonster.transform.position = rightPos.position;
                _spawnedMonster.GetComponent<Monster>().speed = -Random.Range(5f, 10f);
                _spawnedMonster.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

    }
}
