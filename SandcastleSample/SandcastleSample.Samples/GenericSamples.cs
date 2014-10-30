using System;
using System.Collections.Generic;

namespace SandcastleSample.Samples
{
    /// <summary>
    /// TODO refer to such class
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public class GenericSamples<TClass>
    {

        #region Generic Methods

        /// <summary>
        /// Generic method
        /// </summary>
        /// <example>
        /// <para>Use reference like this: <code>M:SandcastleSample.Samples.GenericSamples.GenericMethod(``0)</code></para>
        /// </example>
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
        /// </summary>
        /// <example><code>M:SandcastleSample.Samples.GenericSamples.GenericArgumentInMethod(System.Collections.Generic.List{System.String})</code></example>
        /// <param name="items"></param>
        /// <returns></returns>
        public string GenericArgumentInMethod(List<string> items)
        {
            return string.Concat(items);
        }


        #endregion
    }
}
