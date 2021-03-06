using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastAllScript : MonoBehaviour
{
    [SerializeField]
    private float rotateYspeed = 4.0f;
    [SerializeField]
    private float rotateXspeed = 4.0f;
    SpriteRenderer sr;
    Ray SecondRay;
    [SerializeField]
    int maxRayDistance = 30;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - mouseY * rotateYspeed, transform.localEulerAngles.y + mouseX * rotateXspeed, transform.localEulerAngles.z);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastMethod();
        }
    }

    public void RaycastMethod()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = new Ray(this.transform.position, this.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.gameObject.name == "Left")
            {

                RaycastAllCommonMethod(hit, Vector3.right);
            }
            else if (hit.collider.gameObject.name == "Right")
            {

                RaycastAllCommonMethod(hit, Vector3.left);
            }
            else if (hit.collider.gameObject.name == "Up")
            {

                RaycastAllCommonMethod(hit, Vector3.down);
            }
            else if (hit.collider.gameObject.name == "Bottom")
            {

                RaycastAllCommonMethod(hit, Vector3.up);
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.red, 2f);
        }
    }
    private void RaycastAllCommonMethod(RaycastHit hit, Vector3 directionRay)
    {
        SecondRay = new Ray(hit.transform.position, directionRay);
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
    IEnumerator ResetCubeColor(GameObject CurrectCube)
    {
        yield return new WaitForSeconds(2);
        CurrectCube.GetComponent<Renderer>().material.color = Color.white;
    }
}
