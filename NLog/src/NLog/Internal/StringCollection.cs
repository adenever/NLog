// 
// Copyright (c) 2004 Jaroslaw Kowalski <jaak@polbox.com>
// 
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// * Redistributions of source code must retain the above copyright notice, 
//   this list of conditions and the following disclaimer. 
// 
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution. 
// 
// * Neither the name of the Jaroslaw Kowalski nor the names of its 
//   contributors may be used to endorse or promote products derived from this
//   software without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
// THE POSSIBILITY OF SUCH DAMAGE.
// 

#if NETCF

// a substitute for the missing .NET CF Class

using System;
using System.Collections;
using System.Text;

namespace System.Collections.Specialized
{
	/// <summary>
	/// A collection of elements of type String
	/// </summary>
	public class StringCollection: System.Collections.CollectionBase
	{
		/// <summary>
		/// Initializes a new empty instance of the StringCollection class.
		/// </summary>
		public StringCollection()
		{
			// empty
		}

		/// <summary>
		/// Initializes a new instance of the StringCollection class, containing elements
		/// copied from an array.
		/// </summary>
		/// <param name="items">
		/// The array whose elements are to be added to the new StringCollection.
		/// </param>
		public StringCollection(String[] items)
		{
			this.AddRange(items);
		}

		/// <summary>
		/// Initializes a new instance of the StringCollection class, containing elements
		/// copied from another instance of StringCollection
		/// </summary>
		/// <param name="items">
		/// The StringCollection whose elements are to be added to the new StringCollection.
		/// </param>
		public StringCollection(StringCollection items)
		{
			this.AddRange(items);
		}

		/// <summary>
		/// Adds the elements of an array to the end of this StringCollection.
		/// </summary>
		/// <param name="items">
		/// The array whose elements are to be added to the end of this StringCollection.
		/// </param>
		public virtual void AddRange(String[] items)
		{
			foreach (String item in items)
			{
				this.List.Add(item);
			}
		}

		/// <summary>
		/// Adds the elements of another StringCollection to the end of this StringCollection.
		/// </summary>
		/// <param name="items">
		/// The StringCollection whose elements are to be added to the end of this StringCollection.
		/// </param>
		public virtual void AddRange(StringCollection items)
		{
			foreach (String item in items)
			{
				this.List.Add(item);
			}
		}

		/// <summary>
		/// Adds an instance of type String to the end of this StringCollection.
		/// </summary>
		/// <param name="value">
		/// The String to be added to the end of this StringCollection.
		/// </param>
		public virtual void Add(String value)
		{
			this.List.Add(value);
		}

		/// <summary>
		/// Determines whether a specfic String value is in this StringCollection.
		/// </summary>
		/// <param name="value">
		/// The String value to locate in this StringCollection.
		/// </param>
		/// <returns>
		/// true if value is found in this StringCollection;
		/// false otherwise.
		/// </returns>
		public virtual bool Contains(String value)
		{
			return this.List.Contains(value);
		}

		/// <summary>
		/// Return the zero-based index of the first occurrence of a specific value
		/// in this StringCollection
		/// </summary>
		/// <param name="value">
		/// The String value to locate in the StringCollection.
		/// </param>
		/// <returns>
		/// The zero-based index of the first occurrence of the _ELEMENT value if found;
		/// -1 otherwise.
		/// </returns>
		public virtual int IndexOf(String value)
		{
			return this.List.IndexOf(value);
		}

		/// <summary>
		/// Inserts an element into the StringCollection at the specified index
		/// </summary>
		/// <param name="index">
		/// The index at which the String is to be inserted.
		/// </param>
		/// <param name="value">
		/// The String to insert.
		/// </param>
		public virtual void Insert(int index, String value)
		{
			this.List.Insert(index, value);
		}

		/// <summary>
		/// Gets or sets the String at the given index in this StringCollection.
		/// </summary>
		public virtual String this[int index]
		{
			get
			{
				return (String) this.List[index];
			}
			set
			{
				this.List[index] = value;
			}
		}

		/// <summary>
		/// Removes the first occurrence of a specific String from this StringCollection.
		/// </summary>
		/// <param name="value">
		/// The String value to remove from this StringCollection.
		/// </param>
		public virtual void Remove(String value)
		{
			this.List.Remove(value);
		}

		/// <summary>
		/// Type-specific enumeration class, used by StringCollection.GetEnumerator.
		/// </summary>
		public class Enumerator: System.Collections.IEnumerator
		{
			private System.Collections.IEnumerator wrapped;

			public Enumerator(StringCollection collection)
			{
				this.wrapped = ((System.Collections.CollectionBase)collection).GetEnumerator();
			}

			public String Current
			{
				get
				{
					return (String) (this.wrapped.Current);
				}
			}

			object System.Collections.IEnumerator.Current
			{
				get
				{
					return (String) (this.wrapped.Current);
				}
			}

			public bool MoveNext()
			{
				return this.wrapped.MoveNext();
			}

			public void Reset()
			{
				this.wrapped.Reset();
			}
		}

		/// <summary>
		/// Returns an enumerator that can iterate through the elements of this StringCollection.
		/// </summary>
		/// <returns>
		/// An object that implements System.Collections.IEnumerator.
		/// </returns>        
		public new virtual StringCollection.Enumerator GetEnumerator()
		{
			return new StringCollection.Enumerator(this);
		}
	}
}
#endif
