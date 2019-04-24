function formInputsToXML(formID) {
    var thisform = document.getElementById(formID);
    var elements = thisform.elements;
      alert(elements.length);

    var out_string = '<' + formID + '>';
    for (i = 0; i < elements.length; i++) {
        // alert(i + elements[i].name + elements[i].value);
        form_elem = elements[i];
        if (form_elem.type == "text" || form_elem.type == "textarea") {
            out_string += '<' + form_elem.name + '>';
            out_string += form_elem.value;
            out_string += '</' + form_elem.name + '>';
        }
        //---radio
        if (form_elem.type == "radio" && form_elem.checked == true) {
            out_string += '<' + form_elem.name + '>';
            out_string += form_elem.checked;
            out_string += '</' + form_elem.name + '>';
        }
        //---select
        if (form_elem.type == "select-one") {
            var selectValue = form_elem.options[form_elem.selectedIndex].value;
            out_string += '<' + form_elem.name + '>';
            out_string += selectValue;
            out_string += '</' + form_elem.name + '>' ;
     
        }

    }
    out_string += '</' + formID + '>';
   return out_string;

}
function showXMLData(xmlStr) {
    var xmlDataArray;
    var parser = new DOMParser();
    xmlDoc = parser.parseFromString(xmlStr, "text/xml");
    var nodeList = xmlDoc.getElementsByTagName("id");
    alert(nodeList.length);
    attValue = nodeList[0].getAttribute("value");
    alert(attValue);
}


function formXMLDataToArray(xmlStr) {
    var xmlDataArray;
    var parser = new DOMParser();
    xmlDoc = parser.parseFromString(xmlStr, "text/xml");
    var nodeList = xmlDoc.getElementsByTagName("orderForm1");
    //    alert(entryList.length);
    var i;
    for (i = 0; i < nodeList.length; i++)
      {var nodeList2;
       nodeList2 = nodeList[i].childNodes;
       //alert(childNodes.length);
       alert(nodeList2[2].nodeName);
        //  alert(nodeList2[2].nodeValue);
       var nodeList3;
       nodeList3 = nodeList2[2].childNodes;
       alert(nodeList3[0].nodeName);
       alert(nodeList3[0].nodeValue);
  
       }
}
