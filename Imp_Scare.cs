using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Imp_Scare : MonoBehaviour
{
    public GameObject enemyImpPrefab;
    public Transform player;
    public GameEnding gameEnding;
    public float stillTime = 0f;
    private float stillLimit = 5f;
    private bool isStill = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if(Input.anyKey)
        {
            stillTime = 0f;
        }
        else
        {
            stillTime += Time.deltaTime;

            if(stillTime >= stillLimit && !isStill)
            {
                isStill = true;
                Instantiate(enemyImpPrefab, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 2.75f, Camera.main.transform.position.z + 1), Quaternion.Euler(45,-180,0));
                StartCoroutine(DelayEnding());
            }
        }
    }

    IEnumerator DelayEnding()
    {
        yield return new WaitForSeconds(2f);
        gameEnding.CaughtPlayer();

    }
    
    
}
