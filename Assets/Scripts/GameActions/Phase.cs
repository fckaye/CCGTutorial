using System;
using System.Collections;
using TheLiquidFire.AspectContainer;

namespace GameActions
{
    public class Phase
    {
        #region Fields
        public readonly GameAction owner;
        public readonly Action<IContainer> handler;
        public Func<IContainer, GameAction, IEnumerator> viewer;
        #endregion
        
        #region Constructor
        public Phase(GameAction owner, Action<IContainer> handler)
        {
            this.owner = owner;
            this.handler = handler;
        }
        #endregion
        
        #region Public
        public IEnumerator Flow(IContainer game)
        {
            bool hitKeyFrame = false;

            if (viewer != null)
            {
                var sequence = viewer(game, owner);
                while (sequence.MoveNext())
                {
                    var isKeyFrame = (sequence.Current is bool) ? (bool)sequence.Current : false;
                    if (isKeyFrame)
                    {
                        hitKeyFrame = true;
                        handler(game);
                    }
                    yield return null;
                }
            }

            if (!hitKeyFrame)
            {
                handler(game);
            }
        }
        #endregion
    }
}