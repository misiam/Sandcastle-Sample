namespace SandcastleSample.Samples
{
    /// <summary>
    /// <para>
    /// Use #ctor instead of the name. 
    /// </para> 
    /// </summary>
    public class ConstructorsSamples
    {
        /// <summary>
        /// ctor without argumets
        /// <para>If ctor has not arguments: <code>M:SandcastleSample.Samples.ConstructorsSamples.#ctor</code></para>
        /// </summary>
        public ConstructorsSamples()
        {
            
        }

        /// <summary>
        /// ctor with arguments
        /// <para>If ctor has arguments, they should be specified without spaces, arguments types with namespaces: </para>
        /// <code>M:SandcastleSample.Samples.ConstructorsSamples.#ctor(System.String,System.Int32</code>
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public ConstructorsSamples(string param1, int param2)
        {
            
        }


        /// <summary>
        /// ConstructorsSamples ctor
        /// <para>cctor is used to link to the static constructor. Also private/protected methods could be hiddend in the created documentation.</para>
        /// <code>M:SandcastleSample.Samples.ConstructorsSamples.#cctor</code>
        /// </summary>
        static ConstructorsSamples()
        {
            
        }
    }
}
