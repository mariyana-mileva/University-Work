
const button1 = document.getElementById('btn-style1');
const button2 = document.getElementById('btn-style2');
const button3 = document.getElementById('btn-style3');


button1.addEventListener('click', switchStyles);
button2.addEventListener('click', switchStyles2);
button3.addEventListener('click', switchStyles3);




function switchStyles(){
    document.getElementById("switch").setAttribute("href","style1.css");
}



function switchStyles2(){
    document.getElementById("switch").setAttribute("href","style2.css");
}

function switchStyles3(){
    document.getElementById("switch").setAttribute("href","style3.css");
}






