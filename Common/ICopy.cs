using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Common
{
    /// <summary>Поддерживает различные методы копирования</summary>
    /// <typeparam name="T">Тип экземпляра</typeparam>
    public interface ICopy<T> where T : class
    {
        T Copy();
    }
}
