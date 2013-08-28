using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace TerrariaApi.Server
{
	public class HandlerCollection<ArgsType>: IEnumerable<HandlerRegistration<ArgsType>> where ArgsType: EventArgs
	{
		// Always handle this collection like an immuteable object to maintain thread safety!
		private List<HandlerRegistration<ArgsType>> registrations;
		private readonly object alterRegistrationsLock = new object();
		public string hookName { get; private set; }

		internal HandlerCollection(string hookName)
		{
			if (string.IsNullOrWhiteSpace(hookName))
				throw new ArgumentException("Invalid hook name.", "hookName");
			
			this.registrations = new List<HandlerRegistration<ArgsType>>();
			this.hookName = hookName;
		}

		public void Register(TerrariaPlugin registrator, HookHandler<ArgsType> handler, int priority)
		{
			if (registrator == null)
				throw new ArgumentNullException("registrator");
			if (handler == null)
				throw new ArgumentNullException("handler");

			var newRegistration = new HandlerRegistration<ArgsType>
			{
				Registrator = registrator,
				Handler = handler,
				Priority = priority
			};

			lock (this.alterRegistrationsLock)
			{
				var registrationsClone = new List<HandlerRegistration<ArgsType>>(this.registrations.Count);
				registrationsClone.AddRange(this.registrations);

				// Highest priority goes up in the list, first registered wins if priority equals.
				int insertionIndex = registrations.Count;
				for (int i = 0; i < registrationsClone.Count; i++)
				{
					if (registrationsClone[i].Priority < priority) {
						insertionIndex = i;
						break;
					}
				}
				registrationsClone.Insert(insertionIndex, newRegistration);

				Interlocked.Exchange(ref this.registrations, registrationsClone);
			}
		}

		public void Register(TerrariaPlugin registrator, HookHandler<ArgsType> handler)
		{
			this.Register(registrator, handler, registrator.Order);
		}

		public bool Deregister(TerrariaPlugin registrator, HookHandler<ArgsType> handler)
		{
			if (registrator == null)
				throw new ArgumentNullException("registrator");
			if (handler == null)
				throw new ArgumentNullException("handler");

			var registration = new HandlerRegistration<ArgsType>
			{
				Registrator = registrator,
				Handler = handler
			};

			lock (this.alterRegistrationsLock)
			{
				int registrationIndex = this.registrations.IndexOf(registration);
				if (registrationIndex == -1)
					return false;

				var registrationsClone = new List<HandlerRegistration<ArgsType>>(this.registrations.Count);
				for (int i = 0; i < this.registrations.Count; i++) 
					if (i != registrationIndex)
						registrationsClone.Add(this.registrations[i]);

				Interlocked.Exchange(ref this.registrations, registrationsClone);
			}

			return true;
		}

		public void Invoke(ArgsType args)
		{
			if (args == null)
				throw new ArgumentNullException("args");
			if (this.registrations.Count == 0)
				return;

			// We handle the registrations collection like an immuteable object, looping through it is always thread safe.
			List<HandlerRegistration<ArgsType>> registrations =	this.registrations;
			foreach (var registration in registrations)
			{
				try
				{
					if (ServerApi.Profiler.WrappedProfiler == null)
					{
						registration.Handler(args);
					}
					else
					{
						Stopwatch watch = new Stopwatch();

						watch.Start();
						try
						{
							registration.Handler(args);
						}
						finally
						{
							watch.Stop();
							ServerApi.Profiler.InputPluginHandlerTime(registration.Registrator, hookName, watch.Elapsed);
						}
					}
				}
				catch (Exception ex)
				{
					ServerApi.LogWriter.ServerWriteLine(string.Format(
						"Plugin \"{0}\" has had an unhandled exception thrown by one of its {1} handlers: \n{2}",
						registration.Registrator.Name, hookName, ex), TraceLevel.Warning);

					ServerApi.Profiler.InputPluginHandlerExceptionThrown(registration.Registrator, hookName, ex);
				}
			}
		}

		IEnumerator<HandlerRegistration<ArgsType>> IEnumerable<HandlerRegistration<ArgsType>>.GetEnumerator()
		{
			return this.registrations.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.registrations.GetEnumerator();
		}
	}
}
