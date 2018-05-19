using TrainMovement.Train;
using TrainMovement.Stage;

namespace OptimalTrajectory
{
    public class Solver
    {
        public Trajectory Solve(BaseTrain train, StationToStationBlock stage, IMethod method) => method.Solve(train, stage);
    }
}
