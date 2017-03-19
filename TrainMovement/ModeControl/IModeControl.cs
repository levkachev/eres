using System;

namespace TrainMovement.ModeControl
{
    public interface IModeControl
    { 
    // Int32 Position { get; protected set; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="train"></param>
    /// <returns></returns>
    Double GetForceBaseResistance(Train.Train train);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="train"></param>
    /// <returns></returns>
    Double GetForcePull(Train.Train train);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="train"></param>
    /// <returns></returns>
    Double GetForceBreak(Train.Train train);
}
}
