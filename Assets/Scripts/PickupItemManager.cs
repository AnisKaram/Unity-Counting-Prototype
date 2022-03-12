using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickupItemManager : MonoBehaviour
{
    #region PRIVATE VARIABLES
    [SerializeField] new Camera camera;
    [SerializeField] Text pickedItemsText;
    [SerializeField] Text counterText;
    int Count;
    string selectableTagStr = "Selectable";
    #endregion PRIVATE VARIABLES

    #region PRIVATE METHODS
    void Awake()
    {
        camera = Camera.main;
    }

    void Start()
    {
        Count = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            // This method 'Input.mousePosition' sometimes won't return 
            // the center of the screen.
            //Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            // Instead we can use this method, since unity stated that 
            // this bug won't be fixed, because they are working on  
            // the new input system (released)
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                var item = hit.transform;
                if (item.CompareTag(selectableTagStr))
                {
                    var itemPicked = item.gameObject;
                    AddScoreWithText();
                    Destroy(itemPicked);

                    int tempItems = GameManager.instance.GetScore();
                    if (tempItems == Count)
                    {
                        GameManager.instance.Win();
                    }
                }
            }
        }
    }

    void AddScoreWithText()
    {
        GameManager.instance.AddScore();
        pickedItemsText.text = "Items Picked: " + GameManager.instance.GetScore().ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        // Increase the count whenever a sphere enters the box
        // Change the tag from Selectable to Collected
        // to prevent from being re-collected from that box
        Count += 1;
        other.gameObject.tag = "Collected";
        counterText.text = "Count : " + Count;
    }
    #endregion PRIVATE METHODS
}
