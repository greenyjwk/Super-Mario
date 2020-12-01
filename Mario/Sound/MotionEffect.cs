using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Mario.Enums;

namespace Mario.Sound
{
    class MotionEffect
    {

        private static MotionEffect instance = new MotionEffect();
        public static MotionEffect Instance { get => instance; set => instance = value; }  
        public static IDictionary< MotionType, SoundEffect> sef = new Dictionary<MotionType, SoundEffect>();

        public static void loadcontent(ContentManager Content)
        {
            SoundEffect BreakBlock = Content.Load<SoundEffect>(SoundString.breakBlock);
            SoundEffect Bump = Content.Load<SoundEffect>(SoundString);
            SoundEffect Flip = Content.Load<SoundEffect>("flip");
            SoundEffect MarioPowerUp = Content.Load<SoundEffect>("marioPowerUp");
            SoundEffect MarioDie  = Content.Load<SoundEffect>("marioDie");
            SoundEffect MarioCoin = Content.Load<SoundEffect>("marioCoin");
            SoundEffect MarioFireball = Content.Load<SoundEffect>("marioFireball");
            SoundEffect MarioJump = Content.Load<SoundEffect>("marioJump");
            SoundEffect MarioOneUp = Content.Load<SoundEffect>("marioOneUp");
            SoundEffect PipeTravel = Content.Load<SoundEffect>("pipeTravel");
            SoundEffect PowerUpAppears = Content.Load<SoundEffect>("powerUpAppears");
            SoundEffect Stomp = Content.Load<SoundEffect>("stomp");
            SoundEffect TakeDamage = Content.Load<SoundEffect>("takeDamage");



            sef.Add(MotionType.breakBlock, BreakBlock);
            sef.Add(MotionType.bump, Bump);
            sef.Add(MotionType.flip, Flip);
            sef.Add(MotionType.marioPowerUp,MarioPowerUp);
            sef.Add(MotionType.marioDie, MarioDie);
            sef.Add(MotionType.marioCoin, MarioCoin);
            sef.Add(MotionType.marioFireball,MarioFireball);
            sef.Add(MotionType.marioJump, MarioJump);
            sef.Add(MotionType.marioOneUp,MarioOneUp);
            sef.Add(MotionType.pipeTravel, PipeTravel);
            sef.Add(MotionType.powerUpAppears,PowerUpAppears);
            sef.Add(MotionType.stomp, Stomp);
            sef.Add(MotionType.takeDamage, TakeDamage);
        }

        public void EffectPlay(MotionType currentState)
        {
        //    SoundEffect sound = sef[currentState];
          //  sound.Play();



        }
    }
}
