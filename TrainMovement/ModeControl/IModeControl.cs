using System;

namespace TrainMovement.ModeControl
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModeControl
    { 
    // Int32 Position { get; protected set; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="train"></param>
    /// <returns></returns>
    Double GetForceBaseResistance(Train.BaseTrain train);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="train"></param>
    /// <returns></returns>
    Double GetForcePull(Train.BaseTrain train);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="train"></param>
    /// <returns></returns>
    Double GetForceBreak(Train.BaseTrain train);
}
}
