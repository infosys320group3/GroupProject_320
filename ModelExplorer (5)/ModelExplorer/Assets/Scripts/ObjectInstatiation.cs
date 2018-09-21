using UnityEngine;


public class ObjectInstatiation : MonoBehaviour {

    /// <summary>
    /// Provides this class Singleton-like behavior
    /// </summary>
    public static ObjectInstatiation instance;

    /// <summary>
    /// Provides references to the spawn locations for the products prefabs
    /// </summary>
    public Transform[] spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Spawn a product on the shelf by providing the name and selling grade
    /// </summary>
    /// <param name="name"></param>
    /// <param name="sellingGrade">0 being the best seller</param>
    public void SpawnProduct(string name, int sellingGrade)
    {
        Instantiate(Resources.Load(name),
            spawnPoint[sellingGrade].transform.position, spawnPoint[sellingGrade].transform.rotation);
    }
}
