using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
    private States myState; 

	// Use this for initialization
	void Start () {
        myState = States.cell;
	}

    // Update is called once per frame
    void Update() {
        //print(myState);
        if(myState == States.cell) {
            state_cell();
        } else if(myState == States.sheets_0) {
            state_sheets_0();
        } else if(myState == States.mirror) {
            state_mirror();
        } else if(myState == States.lock_0) {
            state_lock_0();
        } else if(myState == States.cell_mirror) {
            state_cell_mirror();
        } else if(myState == States.sheets_1) {
            state_sheets_1();
        } else if(myState == States.lock_1) {
            state_lock_1();
        } else if(myState == States.freedom) {
            state_freedom();
        }
    }

    void state_cell() {
        text.text = "You are in a prison cell and you want to escape. There are some dirty " +
            "sheets on the bed, a mirror on the wall, and the door is locked from the outside.\n\n" +
            "Press S to view Sheets, M to view Mirror, L to view Lock.";
		if(Input.GetKeyDown(KeyCode.S)) {
            myState = States.sheets_0;
        } else if(Input.GetKeyDown(KeyCode.M)) {
            myState = States.mirror;
        } else if(Input.GetKeyDown(KeyCode.L)) {
            myState = States.lock_0;
        }
    }
    void state_sheets_0() {
        text.text = "Man these sheets are pretty crappy. How could your life come to this?\n\n" + 
            "Press R to Return to roaming your cell.";
        if(Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell;
        }
    }
    void state_mirror() {
        text.text = "There's a dirty mirror on the wall, and a dirty you staring back. It seems to be loose.\n\n" +
            "Press T to Take the mirror, R to Return to roaming your cell.";
        if(Input.GetKeyDown(KeyCode.T)) {
            myState = States.cell_mirror;
        } else if(Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell;
        }
    }
    void state_lock_0() {
        text.text = "The cell door is firmly locked, and the locking mechanism is on the other side of the cell door. " +
            "You can't see the mechanism from your position\n\n" +
            "Press R to Return to roaming your cell.";
        if(Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell;
        }
    }
    void state_cell_mirror() {
        text.text = "You are in a prison cell and you want to escape. There are some dirty " +
            "sheets on the bed, a mirror in your hand, and the door is locked from the outside.\n\n" +
            "Press S to view Sheets, L to view Lock.";
        if(Input.GetKeyDown(KeyCode.S)) {
            myState = States.sheets_1;
        } else if(Input.GetKeyDown(KeyCode.L)) {
            myState = States.lock_1;
        }
    }
    void state_sheets_1() {
        text.text = "Your sheets still look like poo, but at least you have a mirror to look at yourself instead, " +
            "though it's only a slight improvement from the sheets.\n\n" +
            "Press R to Return to roaming your cell.";
        if(Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell_mirror;
        }
    }
    void state_lock_1() {
        text.text = "Fitting the mirror through the cell bars, you are able to see the locking mechanism that will unlock " +
            "your door and set you free. Seems all you have to do is press some old button to unlock your cell.\n\n" +
            "Press R to Return to roaming your cell, O to Open the door.";
        if(Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell_mirror;
        } else if(Input.GetKeyDown(KeyCode.O)) {
            myState = States.freedom;
        }
    }
    void state_freedom() {
        text.text = "Sweet, sweet freedom! No more dirty cell for you!\n\n" +
            "Press P to Play again.";
        if(Input.GetKeyDown(KeyCode.P)) {
            myState = States.cell;
        }
    }
}
