using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadline = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら廃棄する
        if(transform.position.x < this.deadline)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("衝突：" + other.gameObject.tag);

        //キューブが地面または他のキューブに衝突したときに効果音を鳴らす
        if (other.gameObject.tag == "CubePrefabTag" || other.gameObject.tag == "groundTag")
        {
            // 効果音を再生
            GetComponent<AudioSource>().Play();
        }
    }
}
