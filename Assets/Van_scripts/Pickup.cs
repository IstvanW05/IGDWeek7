using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using Vector3 = UnityEngine.Vector3;

public class Pickup : MonoBehaviour
{

  /*  private void PickupSpawn()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Renderer renderer = sphere.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.red;
        sphere.transform.position = new Vector3(24, 1.5f, 25);
    }
  */
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Item collected!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       // PickupSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
