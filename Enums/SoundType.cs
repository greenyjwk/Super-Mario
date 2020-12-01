using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Enums
{
    public enum MotionType
    {

        breakBlock=0,
        bump=1,
        flip=2,
        marioCoin=3,
        marioDie=4,
        marioFireball=5,
        marioJump=6,
        marioOneUp=7,
        marioPowerUp=8,
        pipeTravel=9,
        powerUpAppears=10,
        stomp=11,
        takeDamage=12
        
    };
    public enum BackgroundMusicType
    {
        clearStage=0,
        gameOver=1,
        timeRunningOut=2
    };
}
