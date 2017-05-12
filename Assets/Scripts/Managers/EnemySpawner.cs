using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Squads{
    public Spawn spawnName;
    public GameObject prefabSquad;
}

public class EnemySpawner : MonoBehaviour {

    private float startCDSpawn;
    private float cooldownSpawn;

    [SerializeField]
    private Squads[] squadList;

    [SerializeField]
    private GameObject[] pathsList;

	// Use this for initialization
	void Awake () {
        startCDSpawn = -3;
        cooldownSpawn = 5;
	}
	
	// Update is called once per frame
	void Update () {
        SpawnEnemy();
	}

    private void SpawnEnemy()
    {
        if (startCDSpawn + cooldownSpawn > Time.time)
            return;

        int _path = Random.Range(0, pathsList.Length);

        Spawn _squadToSpawn = pathsList[_path].GetComponent<AuthorizedSquad>().GetAuthorizedSpawn();
        bool _goesThroughScreen = pathsList[_path].GetComponent<AuthorizedSquad>().IsGoingThroughScreen();

        int _pathVariation = Random.Range(0, pathsList[_path].transform.childCount);

        int _beginPoint = 0;

        Vector3 _positionOfSquad = pathsList[_path].transform.GetChild(_pathVariation).GetChild(_beginPoint).position;
        
        int _endPoint = (_beginPoint + 1);
        Vector3 _destination = pathsList[_path].transform.GetChild(_pathVariation).GetChild(_endPoint).position;

        Quaternion _rotationOfSquad = pathsList[_path].transform.GetChild(_pathVariation).GetChild(_beginPoint).rotation;

        GameObject _squadToInstantiate = null;

        for(int i = 0; i < squadList.Length; i++)
        {
            if(squadList[i].spawnName == _squadToSpawn)
            {
                _squadToInstantiate = squadList[i].prefabSquad;
            }
        }

        GameObject _newSquad = Instantiate(_squadToInstantiate, _positionOfSquad, _rotationOfSquad);

        _newSquad.GetComponent<AIMovementSquad>().SetDestination(_destination);
        _newSquad.GetComponent<AIMovementSquad>().SetWaitingAtDestination(!_goesThroughScreen);

        startCDSpawn = Time.time;
    }
}
