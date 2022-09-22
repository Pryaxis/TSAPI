using System.Collections;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace TerrariaApi.Server
{
	public delegate void HookHandler<in ArgumentType>(ArgumentType args) where ArgumentType : EventArgs;

	/// <summary>
	/// Contains a collection of handlers for a particular argument type
	/// </summary>
	/// <typeparam name="ArgsType">Type of arguments that will be sent to the handler</typeparam>
	public class HandlerCollection<ArgsType> : IEnumerable<HandlerRegistration<ArgsType>> where ArgsType : EventArgs
	{

		// Always handle this collection like an immuteable object to maintain thread safety!
		private List<HandlerRegistration<ArgsType>> registrations;
		private readonly object alterRegistrationsLock = new object();
		public string HookName { get; private set; }

		internal HandlerCollection(string hookName)
		{
			if (string.IsNullOrWhiteSpace(hookName))
				throw new ArgumentException("Invalid hook name.", "hookName");

			this.registrations = new List<HandlerRegistration<ArgsType>>();
			this.HookName = hookName;
		}

		public void Register<TLogger>(HookHandler<ArgsType> handler, ILogger<TLogger> logger, int priority)
		{
			if (handler == null)
				throw new ArgumentNullException("handler");

			var newRegistration = new HandlerRegistration<ArgsType>
			{
				Handler = handler,
				Logger = logger,
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
					if (registrationsClone[i].Priority < priority)
					{
						insertionIndex = i;
						break;
					}
				}
				registrationsClone.Insert(insertionIndex, newRegistration);

				Interlocked.Exchange(ref this.registrations, registrationsClone);
			}
		}

		public void Register<TLogger>(HookHandler<ArgsType> handler, ILogger<TLogger> logger)
		{
			this.Register(handler, logger, 0);
		}

		public bool Deregister(HookHandler<ArgsType> handler)
		{
			if (handler == null)
				throw new ArgumentNullException("handler");

			var registration = new HandlerRegistration<ArgsType>
			{
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
			List<HandlerRegistration<ArgsType>> registrations = this.registrations;
			foreach (var registration in registrations)
			{
				try
				{
					registration.Handler(args);
				}
				catch (Exception ex)
				{
					registration.Logger.LogError(ex, "Unhandled exception thrown by handler for hook '{hook'}", HookName);
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
