using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observer {

	void OnNotify();

}

public abstract class Observable {

	private List<Observer> observers = new List<Observer>();

	public void Register(Observer observer) {
		observers.Add(observer);
	}

	public void Unregister(Observer observer) {
		observers.Remove(observer);
	}

	public void Notify() {
		foreach (Observer observer in observers) {
			if (observer == null) {
				observers.Remove(observer);
			} else {
				observer.OnNotify();
			}
		}
	}

}