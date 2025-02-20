using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private void PickupSpawn()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Renderer renderer = sphere.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.red;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Pickup")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Item collected!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PickupSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
