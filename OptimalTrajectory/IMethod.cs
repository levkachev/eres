using TrainMovement.Train;
using TrainMovement.Stage;

namespace OptimalTrajectory
{
    public interface IMethod
    {
        Trajectory Solve(BaseTrain train, StationToStationBlock stage);
    }
}
