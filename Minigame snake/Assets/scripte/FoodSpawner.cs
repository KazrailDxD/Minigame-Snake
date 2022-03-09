using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject foospref =null;
    [SerializeField] float foodspawntime = 3.0f;

    [Header("Area")]
    [SerializeField] float width = 10;
    [SerializeField] float height= 0;
    [SerializeField] float depth = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFood());
    }


   IEnumerator SpawnFood()
    {

        while (true)
        {
            yield return new WaitForSeconds(foodspawntime);

            Vector3 rngPosition = new Vector3(Random.Range(-width,width),Random.Range(-height,height),Random.Range(-depth,depth)) +transform.position;
            Instantiate(foospref, rngPosition, Quaternion.identity);

        }
    }
}
