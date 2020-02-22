//Sample Javascript function
function hello() {
    alert('hello');
    return true;
}

//Validates Date must not be greater than today
function CheckLeaveDateRange(sender, args) {
    var TodayDate = new Date();

    if (sender._selectedDate > TodayDate) {
        alert("The selected date can't be greater than today's date.");
        sender._textbox.set_Value("")
    }
}
function CheckLeaveDateRangeForLeave(sender, args) {
    var today = new Date();
    today.setDate(today.getDate() - 7);
    if (sender._selectedDate < today) {

        if (sender._selectedDate < new Date()) {
            alert("You cannot select a date, which is 7 days before than today's date! \n So, please select a correct date.");
            sender._selectedDate = new Date();
            // set the date back to the current date
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
    }
}
//Validates is Numeric
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

//Check/UnCheck all CheckBox(s) of a given GridView
//Changes Selected Row Color
function GridViewCheckAll(objRef) {
    var GridView = objRef.parentNode.parentNode.parentNode;
    var inputList = GridView.getElementsByTagName("input");

    for (var i = 0; i < inputList.length; i++) {
        //Get the Cell To find out ColumnIndex
        var row = inputList[i].parentNode.parentNode;

        if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
            if (objRef.checked) {
                //If the header checkbox is checked check all checkboxes and highlight all rows
                row.style.backgroundColor = "#FFFF99";
                inputList[i].checked = true;
            }
            else {
                //If the header checkbox is checked uncheck all checkboxes and change rowcolor back to original
                row.style.backgroundColor = "#FFFFFF";
                inputList[i].checked = false;
            }
        }
    }
}

//Changes Selected Row Color
function GridViewCheck(objRef) {
    //Get the Row based on checkbox
    var row = objRef.parentNode.parentNode;

    if (objRef.checked) {
        row.style.backgroundColor = "#FFFF99";
    }
    else {
        row.style.backgroundColor = "#FFFFFF";
    }

    //Get the reference of GridView
    var GridView = row.parentNode;

    //Get all input elements in Gridview
    var inputList = GridView.getElementsByTagName("input");

    for (var i = 0; i < inputList.length; i++) {
        //The First element is the Header Checkbox
        var headerCheckBox = inputList[0];

        //Based on all or none checkboxes are checked check/uncheck Header Checkbox
        var checked = true;

        if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
            if (!inputList[i].checked) {
                checked = false;
                break;
            }
        }
    }

    headerCheckBox.checked = checked;
}

//Handles Mouseevents such as OnMouseOver, OnMouseOut and OnCheckChanged on GridView
function GridViewMouseEvents(objRef, evt) {
    var checkbox = objRef.getElementsByTagName("input")[0];

    if (evt.type == "mouseover") {
        objRef.style.backgroundColor = "#FFFF99";
    }
    else {
        if (checkbox.checked) {
            objRef.style.backgroundColor = "#FFFF99";
        }
        else if (evt.type == "mouseout") {
            objRef.style.backgroundColor = "#FFFFFF";
        }
    }
}


//Handles Ul li menu as accordian menu

