#define ALLOW_RETURNING_EMPTY_ENUMERABLE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ReimplementingLinq.Operators
{
    public partial class Enumerable
    {
        //---------------------------------------------------------------------------------------- 
        // The LINQ actually has a hack in JIT implemented using SZArrayHelper class.
        // .NET VM: A call to an array IList (or IEnumerable or ICollection) has to be handled specifically.
        // These interfaces are 'magic' (mostly due to working set concerned - they are created on
        // demands internally even though semantically, these are static interfaces.
        // Arrays are a bit of a hack in .NET in the first place. 
        // Lets have an example, for instance int[]. We all know that int[] is an Array, but
        // it also a special type. Since int[] implements IEnumerable<int>, it gives us the full power of 
        // LINQ out of the box. From C# point of view, there is no problem. However, from the point of the internals
        // of the VM, this is a big problem, because int[] does not actually implement IEnumerable<int>!
        // The hack is to use SZArray to handle any of those generic methods. So, for example, Empty operator
        // calls GetEnumerator internally on the IEnumerable<int>. The VM finds out that we are trying to call
        // GetEnumerator on an array, and instead of virtually dispatching GetEnumerator on the array instance,
        // it redirects the call to the SZArrayHelper.GetEnumerator<int>() using TypeDependencyAttribute.
        // !The main idea behind all of this - it allows us to treat arrays as if they did actually implement all those
        // generic interfaces - even though they do not!
        //----------------------------------------------------------------------------------------

        public static IEnumerable<TElement> Empty<TElement>()
        {
            return EmptyEnumerable<TElement>.Instance;
        }

        // We have added some optimization in SZArrayHelper class to cache the enumerator of zero length arrays so  
        // the enumerator will be created once per type.

        private class EmptyEnumerable<T> : IEnumerable<T>, IEnumerator<T>
        {
            internal static readonly IEnumerable<T> Instance = new EmptyEnumerable<T>();

            /// <summary>
            /// Prevents the creation of other constructors.
            /// </summary>
            private EmptyEnumerable()
            {
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this;
            }

            public T Current => throw new InvalidOperationException();

            object IEnumerator.Current => throw new InvalidOperationException();

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return false;
            }

            public void Reset()
            {
            }
        }

#if ALLOW_RETURNING_EMPTY_ENUMERABLE
#else

        /// <summary>
        /// Holds and obeys all the necessary caching.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private static class EmptyEnumerable<T>
        {
            internal static readonly T[] Instance = new T[0];
        }
#endif
    }
}
