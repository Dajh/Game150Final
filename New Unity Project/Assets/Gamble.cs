using UnityEngine;
using System.Collections;

public class Gamble : MonoBehaviour {

    public GameObject finish;
    public GameObject fakeFinish1;
    public GameObject fakeFinish2;
    private Vector3 position1;
    private Vector3 position2;
    private Vector3 position3;
    private int fire;
    private int swap;
    private int lastSwap;
    private StartUp startUp;

	// Use this for initialization
	void Start () {
        fire = 0;
        startUp = GameObject.Find("GlobalScripts").GetComponent<StartUp>();
        swap = startUp.rand.Next(1, 4);
        position1 = finish.transform.position;
        position2 = fakeFinish1.transform.position;
        position3 = fakeFinish2.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        fire++;
        if (fire % (startUp.rand.Next(1, 5) * 90) == 0)
        {
            lastSwap = swap;
            //Debug.Log(swap);
            switch (swap)
            {
                case 1:
                    finish.transform.position = position1;
                    fakeFinish1.transform.position = position2;
                    fakeFinish2.transform.position = position3;
                    break;
                case 2:
                    finish.transform.position = position2;
                    fakeFinish1.transform.position = position1;
                    fakeFinish2.transform.position = position3;
                    break;
                case 3:
                    finish.transform.position = position3;
                    fakeFinish1.transform.position = position1;
                    fakeFinish2.transform.position = position2;
                    break;
            }
            fire = 1;
            swap = startUp.rand.Next(1, 4);
            if (swap == lastSwap)
            {
                if (swap == 3)
                {
                    swap--;
                }
                else if (swap == 1)
                {
                    swap++;
                }
            }
        }
    }
}
