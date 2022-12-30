using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class ParticaleRotation : MonoBehaviour
{
    void Update()
    {
        ParticleSystem.MainModule M = this.GetComponent<ParticleSystem>().main;
        M.startRotation = -(this.transform.rotation.eulerAngles.z - 3) / 180 * Mathf.PI;
        //经尝试发现 动态修改 startRotation 的值时使用的是弧度
        if (this.transform.parent.GetComponent<Rigidbody2D>())
        {
            Vector2 ParticleVelocity = (Vector2)this.transform.parent.GetComponent<Rigidbody2D>().velocity *
                this.GetComponent<ParticleSystem>().inheritVelocity.curveMultiplier + new Vector2(0, 4);
            if (ParticleVelocity.x != 0)
            {
                M.startRotation = M.startRotation.constant + Vector2.Angle(new Vector2(0, 1), ParticleVelocity) / 180 * Mathf.PI
                    * ParticleVelocity.x / Mathf.Abs(ParticleVelocity.x + 0.0001F);
            }
        }
    }
}
