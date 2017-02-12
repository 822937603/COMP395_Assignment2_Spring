using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spring : MonoBehaviour {

	public GameObject Anchor;
	public GameObject spring;
	public float K;
    public Slider slider;

	private float startingLangth = 0;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		startingLangth = Anchor.transform.position.y - this.transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.K = slider.value;
		float f = -this.K * (this.transform.position.y - startingLangth);
		rb2d.AddForce(new Vector2(0, f));

		float dis = 4 + ((this.transform.position.y -3)  * 0.5f);
		float tra = (Anchor.transform.position.y - this.transform.position.y) * 0.5f;
		spring.transform.position = new Vector3 (0, dis, 0);
		spring.transform.localScale = new Vector3 (1, tra, 1);
	}
}
