
using UnityEngine;



	[System.Serializable]
	public class DataAttribute
	{
		public double baseHeroValue {
			get { return _baseHeroValue; }
			set {
				_baseHeroValue = value;
				//Debug.LogError("baseHeroValue=" + value);
			}
		}

		private double _baseHeroValue;



		private double addHeroNormalValue;



		public double current;
		private double currentRadio = 1;
		private bool hasChange;


        

		public double value {
			get {
				if (hasChange) {
					current = baseHeroValue  + addHeroNormalValue;
					current = (double)Mathf.Max (0, (float)current) * currentRadio;
					hasChange = false;
					return current;
				} else {
					return current;
				}
			}
		}

		public void AddCurrentRadio (double radio)
		{
			currentRadio += radio;
			hasChange = true;
		}

		public void AddNormalVal(double val){
			addHeroNormalValue += val;
			hasChange = true;
		}


		public void ResumeCurrentRadio ()
		{
			currentRadio = 1;
			hasChange = true;
		}

		public void ResetBaseVal (double value)
		{
			this.baseHeroValue = value;

			hasChange = true;
		}


		public DataAttribute Init (double baseHeroValue)
		{
			ResetBaseVal (baseHeroValue);

			hasChange = true;
			return this;
		}

		public override string ToString ()
		{
			return  " baseHeroValue:" + baseHeroValue;
		}
	}

