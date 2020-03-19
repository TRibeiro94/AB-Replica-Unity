using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* @author Tiago Ribeiro (www.github.com/TRibeiro94)
**/
public class Bird : MonoBehaviour
{
    //public float releaseTime = .15f;
    private Vector3 _initialPosition;                   //private variable to store initial bird position
    private bool _birdWasLaunched;                      //checks if bird was launched
    private float _timeIdle;                            //time the bird is still with no action
    [SerializeField] private float _launchPower = 200;  //SerializeField shows up on the inspector 
    
    private void Awake()                                //Called when the script is being loaded
    {
        _initialPosition = transform.position;
    }

    private void Update()                               //Called once per frame
    {                                                   //for resetting the bird position if he gets out of bounds
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeIdle += Time.deltaTime;                //deltaTime = time since last frame
        }

        if (transform.position.y > 10 || 
           transform.position.y <-10 || 
           transform.position.x > 30 || 
           transform.position.x <-25 ||
           _timeIdle > 3)                               //if it sits for more than 3 seconds   
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;            //activates guiding lines on mouse down
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;           //adds gravity factor on mouse up
        _birdWasLaunched = true;                               
        GetComponent<LineRenderer>().enabled = false;           //deactivates guiding lines on mouse up

        //StartCoroutine(Release());
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }

    /*IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>.enabled = false;
    }*/
}
