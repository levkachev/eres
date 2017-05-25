using System;
using TrainMovement.ModeControl;

namespace TrainMovement.Train
{
    /// <summary>
    /// Содержит выходные параметры поезда после одного шага моделирования движения
    /// </summary>
    public class OutTrainParameters
    {
        /// <summary>
        /// Режим ведения
        /// </summary>
        public IModeControl ModeControl;
        /// <summary>
        /// Ток
        /// </summary>
        public Double Current;
        /// <summary>
        /// Расстояние на перегоне
        /// </summary>
        public Double Space;
        /// <summary>
        /// Время хода по перегону
        /// </summary>
        public Double Time;
        /// <summary>
        /// Координата на линии
        /// </summary>
        public Double Piketage;
        /// <summary>
        /// Скорость
        /// </summary>
        public Double Velocity;

        /// <summary>
        /// 
        /// </summary>
        public Double AdditionalResistance;

        /// <summary>
        /// 
        /// </summary>
        public Double BaseResistance;

        /// <summary>
        /// 
        /// </summary>
        public Double Force;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="modeControl"></param>
        /// <param name="current"></param>
        /// <param name="space"></param>
        /// <param name="time"></param>
        /// <param name="piketage"></param>
        /// <param name="velocity"></param>
        /// <param name="baseResistance"></param>
        /// <param name="force"></param>
        /// <param name="additionalResistance"></param>
        public OutTrainParameters(IModeControl modeControl, Double current, Double space, Double time, Double piketage,Double velocity , Double additionalResistance, Double baseResistance, Double force)
        {
            ModeControl = modeControl;
            Current = current;
            Space = space;
            Time = time;
            Piketage = piketage;
            Velocity = velocity;
            AdditionalResistance = additionalResistance;
            BaseResistance = baseResistance;
            Force = force;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"{ModeControl} I = {Current} F = {Force} S = {Space} t = {Time} Piketage = {Piketage} v = {Velocity} wd = {AdditionalResistance} wb = {BaseResistance}";
        }
    }
}
