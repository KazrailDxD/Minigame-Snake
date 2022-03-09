using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Snakemove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float directionspeed = 180.0f;
    [SerializeField] int gap = 1;
    [SerializeField] float moveSpeedbody = 5.0f;


    [SerializeField] GameObject bodyPref = null;
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionHistory = new List<Vector3>();

    [SerializeField] TextMeshProUGUI scoretext = null;
    public static int score = 0;


    private int foodscore = 5;

    // Update is called once per frame
    void Update()
    {
        //snake move
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        //snake direction
        float direction = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * direction * directionspeed * Time.deltaTime);

        //store positionen
        PositionHistory.Insert(0, transform.position);

        //move bodyparts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Min(index * gap, PositionHistory.Count - 1)];
            Vector3 movedirectionb = point - body.transform.position;
            body.transform.position += movedirectionb * moveSpeedbody * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }

    }

    void GrowSnake()
    {
        GameObject body = Instantiate(bodyPref);
        BodyParts.Add(body);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("food"))
        {
            score += 10;
            foodscore--;
            scoretext.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);
            if(foodscore == 0)
            {
                GrowSnake();
                foodscore = 5;
            }

            
        }
    }
}
