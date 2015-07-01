using System;
using Terraria;

namespace Terraria.World.Generation
{
	internal class GenerationProgress
	{
		private string _message = "";

		private float _value;

		private float _totalProgress;

		public float TotalWeight;

		public float CurrentPassWeight = 1f;

		public string Message
		{
			get
			{
				return string.Format(this._message, this.Value);
			}
			set
			{
				this._message = value.Replace("%", "{0:0%}");
			}
		}

		public float TotalProgress
		{
			get
			{
				return (this.Value * this.CurrentPassWeight + this._totalProgress) / this.TotalWeight;
			}
		}

		public float Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = Utils.Clamp<float>(value, 0f, 1f);
			}
		}

		public GenerationProgress()
		{
		}

		public void End()
		{
			GenerationProgress currentPassWeight = this;
			currentPassWeight._totalProgress = currentPassWeight._totalProgress + this.CurrentPassWeight;
		}

		public void Set(float value)
		{
			this.Value = value;
		}

		public void Start(float weight)
		{
			this.CurrentPassWeight = weight;
			this._value = 0f;
		}
	}
}