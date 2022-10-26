using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarger : MonoBehaviour
{
    [SerializeField] private float growthGoal = 1;
    [SerializeField] private float growthTime = 1;

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

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0,0,.2f);
    }

}
