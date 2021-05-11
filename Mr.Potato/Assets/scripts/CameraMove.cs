using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform player;
    public float xMargin;
    public float yMargin;
    public float SmoothX;
    public float SmoothY;
    Vector3 MinCamXandY;
    Vector3 MaxCamXandY;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        MinCamXandY.x = -5;
        MaxCamXandY.x = 5;
        MinCamXandY.y = -4;
        MaxCamXandY.y = 4;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        TrackPlayer();
    }

    bool NeedMoveX()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool NeedMoveY()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    void TrackPlayer()
    {
        float CamNewX = transform.position.x;
        float CamNewY = transform.position.y;

        if (NeedMoveX())
        {
            CamNewX = Mathf.Lerp(transform.position.x, player.position.x, SmoothX * Time.deltaTime);
        }

        if (NeedMoveY())
        {
            CamNewY = Mathf.Lerp(transform.position.y, player.position.y, SmoothY * Time.deltaTime);
        }

        CamNewX = Mathf.Clamp(CamNewX, MinCamXandY.x, MaxCamXandY.x);
        CamNewY = Mathf.Clamp(CamNewY, MinCamXandY.y, MaxCamXandY.y);
        transform.position = new Vector3(CamNewX, CamNewY, transform.position.z);
    }
}
