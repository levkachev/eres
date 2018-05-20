using System;

namespace TrainMovement.Interpolation.Rusi4
{
    public static class ModeControlFactory
    {
        public static BaseModeControl GetModeControl(ORM.Trains.Entities.ModeControl dummyModeControl, ORM.Trains.Entities.Mass mass)
        {
            switch (dummyModeControl.Name)
            {
                case "Inert":
                    return Inert.GetInstance(mass);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
