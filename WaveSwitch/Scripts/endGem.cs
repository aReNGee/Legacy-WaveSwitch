using UnityEngine;
using System.Collections;
using System.Linq;

public class endGem : MonoBehaviour {
    private bool camPan = false;

    public Renderer spriteRenderer;

    public Transform camTarget;

    Transform camPosition;

    Camera cam;
    float height;
    float width;
    int[] movement;
    static int nextScreen;
    Transform CamOrth;
    //bool alreadyExecuted;
    bool isNxtScrn;

    //position of camera
    static float PosX;
    static float PosY;
    static float PosZ;
    GameObject[] chckPntPos;
    Respawn respawn;
    //int[4] movement;
    static int nextCheckpnt;

    bool nxtScrn;
    // Use this for initialization
    void Start()
    {

        spriteRenderer = GetComponent<Renderer>();
        cam = Camera.main;
        CamOrth = Camera.main.transform;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        // This is the setup of the Level map. 0 right 1 up 2 left and 3 is down
        movement = new int[] { 0, 1, 2, 1, 0, 2};
        nextScreen = -1;
        isNxtScrn = false;

        //Camera Position
        float PosX = Camera.main.transform.position.x;
        float PosY = Camera.main.transform.position.y;
        float PosZ = Camera.main.transform.position.z;

        //alreadyExecuted = false;
        nxtScrn = false;

        //get checkpoint position
        chckPntPos = GameObject.FindGameObjectsWithTag("CheckPoint").OrderBy(go => go.name).ToArray();

        //set next checkpoint
        nextCheckpnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (camPan == true)
        {
            //Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, camTarget.position, 0.06f) + new Vector3 (0, 0, -10);
            if (movement.Length > nextScreen)
                if (movement[nextScreen] == 0)
                {
                    if (CamOrth.position.x < width)
                        CamOrth.position = Vector3.Lerp(CamOrth.position, new Vector3(PosX + width, CamOrth.position.y, -1), 1.5f * 3.0f * Time.deltaTime);
                    if (CamOrth.position.x == PosX + width)
                    {
                    }

                }
                else if (movement[nextScreen] == 1)
                {
                    
                    CamOrth.position = Vector3.Lerp(CamOrth.position, new Vector3(CamOrth.position.x, PosY + height, -1), 1.5f * 3.0f * Time.deltaTime);
                    if (CamOrth.position.y == PosY + height)
                    {
                        //PosY = PosY + height;
                        //Debug.Log("made it");
                    }

                }
                else if (movement[nextScreen] == 2)
                {
                    //if (CamOrth.position.x > 0)
                    //{
                        CamOrth.position = Vector3.Lerp(CamOrth.position, new Vector3((PosX - width), CamOrth.position.y, -1), 1.5f * 3.0f * Time.deltaTime);
                    //}
                    //else if(CamOrth.position.x < 0)
                    //{
                    //    CamOrth.position = new Vector3(0, CamOrth.position.y, CamOrth.position.z);
                    //}
          
                }
                //else if (movement[nextScreen] == 3)
                //{
                //    //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(-(Camera.main.transform.position.x + width * 0.14f), -(Camera.main.transform.position.y + height * 0.13f), 0), 0.01f) + new Vector3(0, 0, -10);

                //    CamOrth.position = Vector3.Lerp(CamOrth.position, new Vector3(CamOrth.position.x, PosY + height, 0), 1f);
                //}


        }

        if (isNxtScrn)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            transform.position = chckPntPos[nextCheckpnt].transform.position;
            if(transform.position == chckPntPos[nextCheckpnt].transform.position)
            {

                GetComponent<BoxCollider2D>().enabled = true;
            }
            nextCheckpnt++;
            isNxtScrn = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            camPan = true;
            nextScreen++;
            isNxtScrn = true;
            nxtScrn = true;
            //Respawn.cpCounter++;
            Update();
            

        }
        else
        {
            camPan = false;
            PosX = CamOrth.position.x;
            PosY = CamOrth.position.y;
            PosZ = CamOrth.position.z;

            //Respawn.cpCounter++;;
        }

        
    }


}
