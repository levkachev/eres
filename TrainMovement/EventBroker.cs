using System;
using System.Collections.Generic;

namespace TrainMovement
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class EventBroker : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<Delegate> subscriptions = new List<Delegate>();

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        /// <exception cref="MemberAccessException">Вызывающий код не имеет доступа к методу, представленному делегатом (например, если это закрытый метод).-или- Количество, порядок или тип параметров в списке <paramref name="args" /> является недопустимым. </exception>
        /// <exception cref="System.Reflection.TargetInvocationException">Представленный делегатом метод является методом экземпляра, а целевой объект имеет значение null.-или- Один из инкапсулированных методов выбрасывает исключение. </exception>
        public void Publish<T>(Object sender, T args) 
        {
            foreach (var subscription in subscriptions)
                subscription.DynamicInvoke(sender, args);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribe(Delegate handler) => subscriptions.Add(handler);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        public void Unsubscribe(Delegate handler) => subscriptions.Remove(handler);

        /// <summary>
        /// 
        /// </summary>
        private void UnsubscribeAll() => subscriptions.Clear();

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public void Dispose() => UnsubscribeAll();
    }
}
