using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject enemy;
    private Coroutine _coroutine;
    private int _counter = 0;
    void Start()
    {
        _coroutine=StartCoroutine(CreateEnemies());
    }

    void Update()
    {
        if (_counter == 5)
        {
            StopCoroutine(_coroutine);
        }
    }
    IEnumerator CreateEnemies()
    {
        while (true)
        {
            Instantiate(enemy, new Vector3(Random.Range(-6f,10f), Random.Range(3f,8f), Random.Range(-14f,30f)), Quaternion.identity);
            yield return new WaitForSecondsRealtime(2f);
            _counter++;
        }
    }
}
