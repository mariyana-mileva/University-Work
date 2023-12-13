const modalBtn1 = document.getElementById("read-more-button-assignment1");
const modalBtn2 = document.getElementById("read-more-button-assignment2");
const modalBtn3 = document.getElementById("read-more-button-assignment3");
const modalBtn4 = document.getElementById("read-more-button-assignment4");

const modalBtn5 = document.getElementById("read-more-button-assignment5");
const modalBtn6 = document.getElementById("read-more-button-assignment6");
const modalBtn7 = document.getElementById("read-more-button-assignment7");

const closeBtn1 = document.getElementById("close-btn1");


const content1 = document.getElementById("content-1");
const content2 = document.getElementById("content-2");
const content3 = document.getElementById("content-3");
const content4 = document.getElementById("content-4");
const content5 = document.getElementById("content-5");
const content6 = document.getElementById("content-6");
const content7 = document.getElementById("content-7");


modalBtn1.addEventListener("click", toggleModal1);
modalBtn2.addEventListener("click", toggleModal2);
modalBtn3.addEventListener("click", toggleModal3);
modalBtn4.addEventListener("click", toggleModal4);
modalBtn5.addEventListener("click", toggleModal5);
modalBtn6.addEventListener("click", toggleModal6);
modalBtn7.addEventListener("click", toggleModal7);

closeBtn1.addEventListener("click", closeModal);





function toggleModal1(){
    const modal = document.getElementById("modal-1");
    content1.style.display = "grid";
    content2.style.display = "none";
    content3.style.display = "none";
    content4.style.display = "none";
    content5.style.display = "none";
    content6.style.display = "none";
    content7.style.display = "none";

    modal.style.display = "block";
}

function toggleModal2(){
    console.log("Is clicked");
    const modal = document.getElementById("modal-1");
    content2.style.display = "grid";
    content1.style.display = "none";
    content3.style.display = "none";
    content4.style.display = "none";
    content5.style.display = "none";
    content6.style.display = "none";
    content7.style.display = "none";


    modal.style.display = "block";
}

function toggleModal3(){
    console.log("Is clicked");
    const modal = document.getElementById("modal-1");
    content3.style.display = "grid";
    content1.style.display = "none";
    content2.style.display = "none";
    content4.style.display = "none";
    content5.style.display = "none";
    content6.style.display = "none";
    content7.style.display = "none";

    modal.style.display = "block";
}

function toggleModal4(){
    console.log("Is clicked");
    const modal = document.getElementById("modal-1");
    content4.style.display = "grid";
    content1.style.display = "none";
    content3.style.display = "none";
    content2.style.display = "none";
    content5.style.display = "none";
    content6.style.display = "none";
    content7.style.display = "none";

    modal.style.display = "block";
}


function toggleModal5(){
    console.log("Is clicked");
    const modal = document.getElementById("modal-1");
    content5.style.display = "grid";
    content1.style.display = "none";
    content3.style.display = "none";
    content4.style.display = "none";
    content2.style.display = "none";
    content6.style.display = "none";
    content7.style.display = "none";

    modal.style.display = "block";
}


function toggleModal5(){
    console.log("Is clicked");
    const modal = document.getElementById("modal-1");
    content5.style.display = "grid";
    content1.style.display = "none";
    content3.style.display = "none";
    content4.style.display = "none";
    content2.style.display = "none";
    content6.style.display = "none";
    content7.style.display = "none";

    modal.style.display = "block";
}


function toggleModal6(){
    console.log("Is clicked");
    const modal = document.getElementById("modal-1");
    content6.style.display = "grid";
    content1.style.display = "none";
    content3.style.display = "none";
    content4.style.display = "none";
    content5.style.display = "none";
    content2.style.display = "none";
    content7.style.display = "none";

    modal.style.display = "block";
}


function toggleModal7(){
    console.log("Is clicked");
    const modal = document.getElementById("modal-1");
    content7.style.display = "grid";
    content1.style.display = "none";
    content2.style.display = "none";
    content3.style.display = "none";
    content4.style.display = "none";
    content5.style.display = "none";
    content6.style.display = "none";

    modal.style.display = "block";
}


function closeModal(){
    console.log("clicked");
    const modal = document.getElementById("modal-1");
    modal.style.display = "none";
    
}

window.onclick = function(event){
    const overlay = document.getElementById("overlay");

    if(event.target == overlay){
        closeModal(); 
    }
}