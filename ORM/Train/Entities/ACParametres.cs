using System;

namespace ORM.Train.Entities
{
    public class ACParametres : TrainBaseParametres
    {
        private Int32 nbAuto;

        public Int32 NBAuto
        {
            get { return nbAuto; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                nbAuto = value;
            }
        }
    }
}
