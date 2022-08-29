using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private float upForce = 1f;
    [SerializeField] private float sideForce = .1f;
    [SerializeField] private float TimeToDeactive = 3;

    private float timer = 0;
    public void SpawnObject(Vector3 pos)
    {
        timer = 0;

        transform.position = pos;

        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce/2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3 (xForce, yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;

        gameObject.SetActive(true);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > TimeToDeactive) DeActive();
    }

    public void DeActive()
    {
        gameObject.SetActive(false);
    }
}
