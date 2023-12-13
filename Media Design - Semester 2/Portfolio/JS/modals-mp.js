const modalBtn1 = document.getElementById("read-more-button-assignment1");
const modalBtn2 = document.getElementById("read-more-button-assignment2");
const modalBtn3 = document.getElementById("read-more-button-assignment3");

const closeBtn1 = document.getElementById("close-btn1");


const content1 = document.getElementById("content-1");
const content2 = document.getElementById("content-2");
const content3 = document.getElementById("content-3");



modalBtn1.addEventListener("click", toggleModal1);
modalBtn2.addEventListener("click", toggleModal2);
modalBtn3.addEventListener("click", toggleModal3);

closeBtn1.addEventListener("click", closeModal);



function toggleModal1(){
    const modal = document.getElementById("modal-1");
    content1.style.display = "grid";
    content2.style.display = "none";
    content3.style.display = "none";

    modal.style.display = "block";
}

function toggleModal2(){
    console.log("Is clicked");
    const modal = document.getElementById("modal-1");
    content2.style.display = "grid";
    content1.style.display = "none";
    content3.style.display = "none";


    modal.style.display = "block";
}

function toggleModal3(){
    console.log("Is clicked");
    const modal = document.getElementById("modal-1");
    content3.style.display = "grid";
    content1.style.display = "none";
    content2.style.display = "none";

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