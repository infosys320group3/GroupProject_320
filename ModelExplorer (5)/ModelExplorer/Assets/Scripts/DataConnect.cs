using UnityEngine;
//using Pathfinding.Serialization.JsonFx; //old method
using Newtonsoft.Json;
using System.Collections;
using UnityEngine.Networking;

public class DataConnect : MonoBehaviour
{
    public GameObject wheelPrefab;
    public GameObject carPrefab;
    public GameObject seatPrefab;
    public GameObject suspensionPrefab;

    //string WebsiteURL = "https://dwhi045.azurewebsites.net/tables/Car?zumo-api-version=2.0.0";

    string WebsiteURL = "https://tmul918.azurewebsites.net/tables/Car?zumo-api-version=2.0.0";

    string jsonResponse;

    void Start()
    {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        //old code string jsonResponse = Request.GET(_WebsiteURL);
        
        WWW myWww = new WWW(WebsiteURL);
        while (myWww.isDone == false) ;

        jsonResponse = myWww.text;
        //StartCoroutine(GetData());
        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        //Car[] Cars = JsonReader.Deserialize<Car[]>(jsonResponse);
        Car[] Cars = JsonConvert.DeserializeObject<Car[]>(jsonResponse);


        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL

        //int totalObjects = 30;
        //float totalDistance = 2.9f;
        //----------------------

        //We can now loop through the array of objects and access each object individually
            
            //Example of how to use the object
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
            //float perc = i / (float)totalObjects;
            //float sin = Mathf.Sin(perc * Mathf.PI / 2);

            //float x = 1 + i * .5f;
            //float y = 0.6f;
            //float z = 2.0f;

        var CarClass = (GameObject)Instantiate(carPrefab, new Vector3(Cars[0].X, Cars[0].Y, Cars[0].Z), Quaternion.identity);
        CarClass.transform.Rotate(0, 180, 0);
        CarClass.transform.Find("New Text").GetComponent<TextMesh>().text = Cars[0].ClassName;

        var WheelClass = (GameObject)Instantiate(wheelPrefab, new Vector3(Cars[1].X, Cars[1].Y, Cars[1].Z), Quaternion.identity);
        WheelClass.transform.Rotate(0, 180, 0);
        WheelClass.transform.Find("New Text").GetComponent<TextMesh>().text = Cars[1].ClassName;

        var SeatClass = (GameObject)Instantiate(seatPrefab, new Vector3(Cars[2].X, Cars[2].Y, Cars[2].Z), Quaternion.identity);
        SeatClass.transform.Rotate(0, 180, 0);
        SeatClass.transform.Find("New Text").GetComponent<TextMesh>().text = Cars[2].ClassName;

        var SuspensionClass = (GameObject)Instantiate(suspensionPrefab, new Vector3(Cars[3].X, Cars[3].Y, Cars[3].Z), Quaternion.identity);
        SuspensionClass.transform.Rotate(0, 180, 0);
        SuspensionClass.transform.Find("New Text").GetComponent<TextMesh>().text = Cars[3].ClassName;

        //newObject.GetComponent<CubeScript>().SetSize(.45f * (1.0f - perc));
        //newObject.GetComponent<CubeScript>().rotateSpeed = .2f + perc * 4.0f;

        //----------------------
    }

    IEnumerator GetData()
    {
        Debug.Log("Getting  Data");
        UnityWebRequest www = UnityWebRequest.Get(WebsiteURL);       
        www.SendWebRequest();
        //yield return www.SendWebRequest();
        {
            Debug.Log("Retrieved  Data For " + WebsiteURL);
            new WaitForSeconds(40);
            
            jsonResponse = www.downloadHandler.text;
            yield return new WaitForSeconds(1);
            //yield return new WaitForSeconds(20);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
