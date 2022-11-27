using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class SpawnOnSurface : MonoBehaviour
{
    [SerializeField] ARRaycastManager RaycastManager;
    [SerializeField] GameObject objectPrefab;
   // [SerializeField] GameObject reticle;
    [SerializeField] ARSessionOrigin arOrigin;
    [SerializeField] Button respawnButton;
  //  private ARMeshManager arMeshManager;
   // bool canSpawn = false;
    Camera aRCamera;
    

    private void Awake()
    {
        // reticle = Instantiate(reticle, transform);
        //  aRCamera = Camera.main;
        // arMeshManager = FindObjectOfType<ARMeshManager>();
        respawnButton.onClick.AddListener(Respawn);
    }
    /*  private void OnEnable()
      {
         // arMeshManager.meshesChanged += MeshesModified;
      }

      void MeshesModified(ARMeshesChangedEventArgs args)
      {
          if(args.added != null)
          {
            canSpawn = true;
          }

      }
     */
    private GameObject spawnedObject;
    void Update()
    {

      /*  if (objectPrefab == null)
        {
            var ray = aRCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            RaycastManager.Raycast(ray, hits, TrackableType.Planes);
           // reticle.transform.position = hits[0].pose.position;
            
        }
      */
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            RaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes);
           // GameObject collisionPoint = hits[0].trackable.gameObject;
           // Debug.Log(Vector2Extensions.IsPointOverUIObject(Input.GetTouch(0).position));

            if (hits.Count > 0 )
            {
                Debug.Log("Avoided UI");
                if (spawnedObject == null)
                {

                    Debug.Log("Spawned");
                    spawnedObject = Instantiate(objectPrefab, hits[0].pose.position, Quaternion.identity);
                     //reticle.SetActive(false);
                    //spawnedObject.transform.LookAt(arOrigin.transform.position);
                    //  spawnedObject.GetComponent<AudioSource>().Play();
                }

              
            }
        }

    }
    void Respawn()
    {
        Debug.Log("Destroyed");
        Destroy(spawnedObject);

    }

 


}
