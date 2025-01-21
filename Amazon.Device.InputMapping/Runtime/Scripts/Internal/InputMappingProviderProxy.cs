using UnityEngine;

namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// A proxy interface for the <c>InputMappingProvider</c>
    /// </summary>
    internal class InputMappingProviderProxy: AndroidJavaProxy
    {

        public InputMappingProvider InputMappingProvider { get; private set; }

        public InputMappingProviderProxy(InputMappingProvider inputMappingProvider) :
            base(JavaConstants.InputMappingProviderClassName)
        {
            InputMappingProvider = inputMappingProvider;
        }

        /// <summary>
        /// Fetches the input mapping provider and converts it into a Java object
        /// </summary>
        public AndroidJavaObject onProvideInputMap()
        {
            var inputMap = InputMappingProvider.OnProvideInputMap();
            return new JavaConverter(inputMap).ToJavaObject();
        }
    }
}