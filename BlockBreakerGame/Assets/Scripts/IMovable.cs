using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable<T> {

    void Move(T moveVector);
	
}
