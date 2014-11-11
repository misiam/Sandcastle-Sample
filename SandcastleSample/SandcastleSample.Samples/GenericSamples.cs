using System;
using System.Collections.Generic;

namespace SandcastleSample.Samples
{
    /// <summary>
    /// <para>To link to the generic class:
    /// <code>T:SandcastleSample.Samples.GenericSamples`1</code>
    /// </para>
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public class GenericSamples<TClass>
    {

        #region Generic Methods

        /// <summary>
        /// Generic method
        /// <example>
        /// <para>Use reference like this: <code>M:SandcastleSample.Samples.GenericSamples`1.GenericMethod``1(``0,`0)</code></para>
        /// </example>
        /// </summary>
        /// <typeparam name="T">T parameter of the type T</typeparam>
        /// <param name="item">Argument</param>
        /// <param name="classArg">Argument</param>
        /// <returns></returns>
        public T GenericMethod<T>(T item, TClass classArg)
        {
            return item;
        }


        /// <summary>
        /// Generic arguments in method
        /// <example><code>M:SandcastleSample.Samples.GenericSamples`1.GenericArgumentInMethod(System.Collections.Generic.List{System.String})</code></example>
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public string GenericArgumentInMethod(List<string> items)
        {
            return string.Concat(items);
        }


        #endregion
    }
}
