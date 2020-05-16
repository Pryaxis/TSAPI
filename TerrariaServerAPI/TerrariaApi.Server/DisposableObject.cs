using System;

namespace TerrariaApi.Server
{
	public class DisposableObject : IDisposable
	{
		///<summary>
		/// Deconstructor. Implements the Dispose pattern.
		///</summary>
		~DisposableObject()
		{
			Dispose(false);
		}

		///<summary>
		/// Implements the Dispose pattern. Disposes the plugin
		///</summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		///<summary>
		/// Implements the Dispose pattern. Release managed resources here.
		///</summary>
		protected virtual void Dispose(bool canDisposeManaged)
		{
			DisposeUnmanaged();
			if(canDisposeManaged)
				DisposeManaged();
		}

		protected virtual void DisposeUnmanaged() { }
		protected virtual void DisposeManaged() { }
	}
}
