using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SikiAngryBird
{
    public class GreenBird : Bird
    {
        public override void ShowSkill()
        {
            base.ShowSkill();
            Vector3 speed = rg.velocity;
            speed.x *= -1;
            rg.velocity = speed;
        }

    }
}