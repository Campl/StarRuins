using UnityEngine;

public class camera : MonoBehaviour {
    public Transform player;
    //public float smoothRate = 0.2f;
    public float left;
    public float right;
    public float x,y;
    GameObject hero;
    private Transform thisTransform;
    private Vector2 velocity;
    void Start () {
        thisTransform = transform;
        velocity = new Vector2(0.5f, 0.5f);
    }
	void Update () {
        hero = GameObject.FindWithTag("Player");
        player = hero.transform;
        if (player.position.x >left&&player.position.x<right)
        {
			this.transform.position = new Vector3(player.transform.position.x - x, thisTransform.position.y, -10);
            //Vector2 newPos2D = Vector2.zero;
            //Mathf.SmoothDamp平滑阻尼
            /*newPos2D.x = Mathf.SmoothDamp(thisTransform.position.x, player.position.x, ref velocity.x, smoothRate);
            Vector3 newPos = new Vector3(newPos2D.x, transform.position.y, transform.position.z);
            //Vector3.Slerp 球形插值  
            transform.position = Vector3.Slerp(transform.position, newPos, Time.time);*/
        }
    }
}
