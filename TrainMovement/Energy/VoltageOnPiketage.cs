using System;

namespace TrainMovement.Energy
{
    public class VoltageOnPiketage
    {
        /// <summary>
        /// 
        /// </summary>
        public Double Voltage { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public Double Piketage { get; }

        /// <summary>
        /// </summary>
        /// <param name="broker"></param>
        /// <param name="dataLine"></param>
        /// <param name="separator"></param>
        /// <exception cref="ArgumentException">
        ///         <paramref name="options" /> не является одним из значений <see cref="T:System.StringSplitOptions" />.</exception>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="s" /> имеет значение null. </exception>
        /// <exception cref="FormatException">Параметр <paramref name="s" /> не представляет число в допустимом формате. </exception>
        /// <exception cref="OverflowException">
        ///         <paramref name="s" /> представляет число, которое меньше <see cref="F:System.Double.MinValue" /> или больше <see cref="F:System.Double.MaxValue" />. </exception>
        public VoltageOnPiketage(String dataLine, String separator = "; ")
        {
            if (dataLine == null)
                throw new ArgumentNullException(nameof(dataLine));

            var currentData = dataLine.Split(new[] { separator }, StringSplitOptions.None);

            if (currentData.Length != 2)
                throw new ArgumentException($"Separator has incorrect format. See for value of {separator} parameter.");
            try
            {
                Piketage = Double.Parse(currentData[0]);
                Voltage = Double.Parse(currentData[1]);
            }
            catch (Exception exception)
            {
                throw new ArgumentException("Piketage or voltage has incorrect format.", exception);
            }
        }
    }
}