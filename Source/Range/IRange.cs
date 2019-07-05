// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

namespace ProtoStar.Math
{
    public interface IRange<out T>
    {
        #region Public Properties

        T Maximum { get; }
        T Minimum { get; }

        #endregion Public Properties
    }
}