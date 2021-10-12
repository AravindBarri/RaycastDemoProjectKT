using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleRaycastScript : MonoBehaviour
{
    public string selectedRaycast = "SimpleRaycast";
    Ray SecondRay;
    float maxRayDistance = 30f;
    [SerializeField]
    private float rotateYspeed = 4.0f;
    [SerializeField]
    private float rotateXspeed = 4.0f;
    public static MultipleRaycastScript instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - mouseY * rotateYspeed, transform.localEulerAngles.y + mouseX * rotateXspeed, transform.localEulerAngles.z);
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedRaycast == "RaycastAll")
            {
                RaycastAllMethod();

            }
            else if (selectedRaycast == "SimpleRaycast")
            {
                RaycastMethod();
            }
            else if (selectedRaycast == "OppositeRaycast")
            {
                RaycastOppositeMethod();
            }
        }
        
    }
    public void RaycastAllMethod()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = new Ray(this.transform.position, this.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.gameObject.name == "Left")
            {

                SecondRay = new Ray(hit.transform.position, Vector3.right);
                RaycastHit[] hits = Physics.RaycastAll(SecondRay, maxRayDistance);

                foreach (RaycastHit rayhit in hits)
                {
                    Debug.DrawRay(SecondRay.origin, SecondRay.direction * rayhit.distance, Color.yellow, 2f);
                    GameObject currentHit = rayhit.collider.gameObject;
                    if (currentHit.GetComponent<Collider>())
                    {
                        currentHit.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
                    }
                    StartCoroutine(ResetCubeColor(currentHit));
                }
            }
            else if (hit.collider.gameObject.name == "Right")
            {

                SecondRay = new Ray(hit.transform.position, Vector3.left);
                RaycastHit[] hits = Physics.RaycastAll(SecondRay, maxRayDistance);

                foreach (RaycastHit rayhit in hits)
                {
                    Debug.DrawRay(SecondRay.origin, SecondRay.direction * rayhit.distance, Color.yellow, 2f);
                    GameObject currentHit = rayhit.collider.gameObject;
                    if (currentHit.GetComponent<Collider>())
                    {
                        currentHit.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
                    }
                    StartCoroutine(ResetCubeColor(currentHit));
                }
            }
            else if (hit.collider.gameObject.name == "Up")
            {

                SecondRay = new Ray(hit.transform.position, Vector3.down);
                RaycastHit[] hits = Physics.RaycastAll(SecondRay, maxRayDistance);

                foreach (RaycastHit rayhit in hits)
                {
                    Debug.DrawRay(SecondRay.origin, SecondRay.direction * rayhit.distance, Color.yellow, 2f);
                    GameObject currentHit = rayhit.collider.gameObject;
                    if (currentHit.GetComponent<Collider>())
                    {
                        currentHit.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
                    }
                    StartCoroutine(ResetCubeColor(currentHit));
                }
            }
            else if (hit.collider.gameObject.name == "Bottom")
            {

                SecondRay = new Ray(hit.transform.position, Vector3.up);
                RaycastHit[] hits = Physics.RaycastAll(SecondRay, maxRayDistance);

                foreach (RaycastHit rayhit in hits)
                {
                    Debug.DrawRay(SecondRay.origin, SecondRay.direction * rayhit.distance, Color.yellow, 2f);
                    GameObject currentHit = rayhit.collider.gameObject;
                    if (currentHit.GetComponent<Collider>())
                    {
                        currentHit.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
                    }
                    StartCoroutine(ResetCubeColor(currentHit));
                }
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.red, 2f);
        }
    }
    public void RaycastOppositeMethod()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = new Ray(this.transform.position, this.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.gameObject.name == "Left")
            {

                SecondRay = new Ray(hit.transform.position, Vector3.right);

                if (Physics.Raycast(SecondRay, out RaycastHit hit2, 100f))
                {
                    Debug.DrawRay(SecondRay.origin, SecondRay.direction * hit2.distance, Color.yellow, 2f);
                    GameObject currentHit = hit2.collider.gameObject;
                    if (currentHit.GetComponent<Collider>())
                    {
                        currentHit.GetComponent<Renderer>().material.color = Color.red;
                    }
                    StartCoroutine(ResetCubeColor(currentHit));
                }
            }
            else if (hit.collider.gameObject.name == "Right")
            {

                SecondRay = new Ray(hit.transform.position, Vector3.left);

                if (Physics.Raycast(SecondRay, out RaycastHit hit2, 100f))
                {
                    Debug.DrawRay(SecondRay.origin, SecondRay.direction * hit2.distance, Color.yellow, 2f);
                    GameObject currentHit = hit2.collider.gameObject;
                    if (currentHit.GetComponent<Collider>())
                    {
                        currentHit.GetComponent<Renderer>().material.color = Color.red;
                    }
                    StartCoroutine(ResetCubeColor(currentHit));
                }
            }
            else if (hit.collider.gameObject.name == "Up")
            {

                SecondRay = new Ray(hit.transform.position, Vector3.down);

                if (Physics.Raycast(SecondRay, out RaycastHit hit2, 100f))
                {
                    Debug.DrawRay(SecondRay.origin, SecondRay.direction * hit2.distance, Color.yellow, 2f);
                    GameObject currentHit = hit2.collider.gameObject;
                    if (currentHit.GetComponent<Collider>())
                    {
                        currentHit.GetComponent<Renderer>().material.color = Color.red;
                    }
                    StartCoroutine(ResetCubeColor(currentHit));
                }
            }
            else if (hit.collider.gameObject.name == "Bottom")
            {

                SecondRay = new Ray(hit.transform.position, Vector3.up);

                if (Physics.Raycast(SecondRay, out RaycastHit hit2, 100f))
                {
                    Debug.DrawRay(SecondRay.origin, SecondRay.direction * hit2.distance, Color.yellow, 2f);
                    GameObject currentHit = hit2.collider.gameObject;
                    if (currentHit.GetComponent<Collider>())
                    {
                        currentHit.GetComponent<Renderer>().material.color = Color.red;
                    }
                    StartCoroutine(ResetCubeColor(currentHit));
                }
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.red, 2f);
        }
    }
    public void RaycastMethod()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = new Ray(this.transform.position, this.transform.forward);

        print(ray.direction);
        //Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue, 2f);
        //RaycastHit hit;
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 2f);
            print(hit.collider.gameObject.name);
            GameObject currentHit = hit.collider.gameObject;
            if (currentHit.GetComponent<Collider>())
            {
                currentHit.GetComponent<Renderer>().material.color = Color.red;
            }
            StartCoroutine(ResetCubeColor(currentHit));
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.red, 2f);
        }
    }
    IEnumerator ResetCubeColor(GameObject CurrectCube)
    {
        yield return new WaitForSeconds(2);
        CurrectCube.GetComponent<Renderer>().material.color = Color.white;
    }
}
