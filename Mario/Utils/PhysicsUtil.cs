using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public static class PhysicsUtil
    {

        public const float maxXVelocity = 5.5f;
        public const float minYVelocity = 45.8f;
        public const float maxYVelocity = 56.0f;
        public const float sprintVelocity = 1.05f;
        public const float firstPhaseXVelocity = 1.5f;
        public const float firstPhaseMultiplier = 0.04f;
        public const float secondPhaseMultiplier = 0.05f;
        public const float jumpPhaseMultiplier = 0.7f;
        public const float notJumpPhaseUtil = 0.9f;
        public const float notJumpPhaseOffset = 0.1f;
        public const float fallDownCheckUtil = -2;
        public const float fallingPhaseCheckUtil = 0.05f;
        public const float upwardMultiplier= 0.7f;
        public const float fallDownMultiplier = 0.02f;
        public const float zero = 0;
        public const float reverseYVelocityDivider = 1.10f;
        public const float gravity = 0.8f;
        public const float jumpFriction = 5;
        public const float upForce = 45;



    }
}
