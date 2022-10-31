using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Daniel Sanchez

public class Enlarger : MonoBehaviour
{
    [SerializeField] private float growthGoal = 1;
    [SerializeField] private float growthTime = 1;
    [SerializeField] float destructionTime;     //added for use with shields/asteroids?/other objects- T.E.

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScaleOverTime(growthTime));
    }
    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 destinationScale = new Vector3(growthGoal, growthGoal, 0);

        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        Destroy(gameObject, destructionTime);
    }

    private void Update()
    {
        transform.Rotate(0,0,.2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "projectile/bullet")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "projectile/rocket")
        {
            Destroy(other.gameObject);
        }
    }
}
