using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class EnnemiAI : MonoBehaviour
{
    public Transform target;
  
    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private SpriteRenderer mySpriteRenderer;
    public float updateRate = 2f;
    public bool acces = true;
    private Seeker seeker;
    private Rigidbody2D rb;
    public float angle;
    //The calcul
    public Path path;

    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //max distance entre deux points 
    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        //direction = 1;
        //someScale = transform.localScale.x;
    }

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
        if (target == null)
        {
            Debug.LogError("No Player found ?");
            return;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath ());
    }

    IEnumerator UpdatePath() {
        if (target == null)
        {
            //TODO: Insert a player search here.
            yield return null;
        }

        seeker.StartPath (transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f/updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete (Path p)
    {
        //Debug.Log("We got a path. Error ?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate ()
    {
        if (target == null)
        {
            //TODO: Insert a player search here
            return;
        }

        //TODO: Always look at player ?
        Vector3 dire = target.position - transform.position;

        if (dire.x > 0 
            && acces == true) {
            
           
            float angle = Mathf.Atan2(dire.x, 90) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector3 lTemp = transform.localScale;
            //lTemp.x *= -1;
            //transform.localScale = lTemp;
            //mySpriteRenderer.flipX = false;
            acces = false;
        }
        if (dire.x <= 0 
            && acces == false)
        {
           
            float angle = Mathf.Atan2(dire.x, 90) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector3 lTemp = transform.localScale;
            //lTemp.x *= -1;
            //transform.localScale = lTemp;
            //mySpriteRenderer.flipX = true;
            acces = true;
        }
        


        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            //Debug.Log("End of path reached.");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to the next Waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //Move the AI
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

    }
}
