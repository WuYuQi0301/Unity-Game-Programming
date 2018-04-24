using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionManager {
    void StartThrow(GameObject diskToThrow);
    int getDiskNumber();
    void setDiskNumber(int _num);
}
