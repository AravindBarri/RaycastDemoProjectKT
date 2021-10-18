using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragScript : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float fireRate = 1f;
    Ray SecondRay;
    [SerializeField]
    float cubeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * cubeSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastMethod();
        }


    }
    
    public void RaycastMethod()
    {

            SecondRay = new Ray(this.transform.position, Vector3.up);

            if (Physics.Raycast(SecondRay, out RaycastHit hit2, 100f))
            {
                Debug.DrawRay(SecondRay.origin, SecondRay.direction * hit2.distance, Color.yellow, 2f);
                GameObject currentHit = hit2.collider.gameObject;
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
