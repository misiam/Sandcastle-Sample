using System.Collections.Generic;

namespace SandcastleSample.Samples
{
    public class MethodsSamples
    {

        /// <summary>
        /// Some class property
        /// </summary>
        /// <example>
        /// <prop>To link to a property in the Sandcastle documentation use that: 
        /// <code>P:SandcastleSample.Samples.MethodsSamples.GetTypeName</code>
        /// </prop>
        /// </example>
        public string GetTypeName
        {
            get { return this.GetType().FullName; }
        }

        /// <summary>
        /// Class indexer
        /// </summary>
        /// <example>
        /// <para>Note that there is difference between the documentation xml and the cref item.</para>
        /// <para>documentation xml: <code>P:SandcastleSample.Samples.MethodsSamples.Item(System.Int32)</code></para>
        /// <para>cref: <see cref="SandcastleSample.Samples.MethodsSamples.get_Item"/><code>&lt;see cref=&quot;SandcastleSample.Samples.MethodsSamples.get_Item&quot;/&gt;</code></para>
        /// </example>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index]
        {
            get { return index.ToString(); }
        }


        #region Ordinal Methods


        /// <summary>
        /// This method without parameters
        /// </summary>
        /// <example>
        /// <para>To link method without parameters: <code>M:SandcastleSample.Samples.MethodsSamples.WithoutParameters</code></para>
        /// </example>
        public string WithoutParameters()
        {
            return "some result";
        }

        /// <summary>
        /// Method with params. 
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        /// <example>params doesn't have some spesial notation: 
        /// <code>M:SandcastleSample.Samples.MethodsSamples.MehtodWithParams(System.String[]) </code>
        /// </example>
        public string MehtodWithParams(params string[] strings)
        {
            return string.Concat(strings);
        }


        /// <summary>
        /// Summarize <see cref="param1"/> and <see cref="param2"/>
        /// </summary>
        /// <param name="param1">parameter 1</param>
        /// <param name="param2">parameter 2</param>
        /// <param name="outValue">out parameter</param>
        /// <example>
        /// <para>Out and ref are used with @: M:SandcastleSample.Samples.MethodsSamples.MethodWithOutParameter(System.Int32,System.Int32,System.Int32@) <code></code></para>
        /// </example>
        /// <returns></returns>
        public void MethodWithOutParameter(int param1, int param2, out int outValue)
        {
            outValue = param1 + param2;
        }

        /// <summary>
        /// Method with referenced parameter
        /// </summary>
        /// <example>
        /// <para>Out and ref are used with @: M:SandcastleSample.Samples.MethodsSamples.MethodWithOutParameter(System.Int32,System.String@) <code></code></para>
        /// </example>
        /// <param name="param1"></param>
        /// <param name="refValue"></param>
        public void MethodWithRefParameter(string param1, ref string refValue)
        {
            refValue += "_added";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>
        ///     <para>To link to both overloads use 'O': <code>O:SandcastleSample.Samples.MethodsSamples.MethodWithOverload</code></para>
        ///     <overloads>
        ///         <para>'overloads' tag used in Sandcastle to put some additional inforation to "Ovetrload methods" page in the documentation.</para> 
        ///     </overloads>
        /// </example>
        /// <param name="param"></param>
        public void MethodWithOverload(string param)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <remarks>
        /// 
        /// </remarks>
        public void MethodWithOverload(int param1, int param2)
        {

        }

        #endregion


        /// <summary>
        /// Protected method. Could be hidden by the Sandcastle
        /// </summary>
        protected void ProtectedMethod()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>
        /// <para>To link to stat method use ordinal method notation: <code>M:SandcastleSample.Samples.MethodsSamples.SomeStaticMethod</code></para>
        /// </example>
        /// <returns></returns>
        public static string SomeStaticMethod()
        {
            return string.Empty;
        }
    }
}
