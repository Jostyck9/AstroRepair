using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroJawa : MonoBehaviour
{
    public JawaManager manager;
    public List<Vector2> listPostion;
    public float speed = 60;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        manager.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (index < listPostion.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(listPostion[index].x, listPostion[index].y, transform.position.z), step);
            if (transform.position.x == listPostion[index].x && transform.position.y == listPostion[index].y)
                index++;
        } else
        {
            this.enabled = false;
            manager.enabled = true;
        }
    }
}
