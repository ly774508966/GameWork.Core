﻿using GameWork.Core.States.Interfaces;

namespace GameWork.Core.States
{
	public abstract class TickState : State
	{
		private readonly ITickStateTransition[] _transitions;

		protected TickState(params ITickStateTransition[] stateTransitions)
		{
			_transitions = stateTransitions;
		}

		internal bool CheckTransitions(out string toStateName)
		{
			var didTransition = false;
			toStateName = null;

			foreach (var transition in _transitions)
			{
				if (transition.IsConditionMet)
				{
					toStateName = transition.ToStateName;
					didTransition = true;
					break;
				}
			}

			return didTransition;
		}
	}
}