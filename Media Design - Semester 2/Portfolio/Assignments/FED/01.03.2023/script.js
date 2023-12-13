const button = document.getElementById("showMessage");
console.log(button);
let toggle = 0;

const imgDivToggle = document.getElementById("toggleImageDiv")

button.addEventListener("click", displayMessage)

function displayMessage(){
    const message = document.getElementById("msg");
    message.style.display = 'block';
}


const buttonImage = document.getElementById("showImage");
const divimg = document.getElementById("imageDiv");
const toggledivimg = document.getElementById("toggleImageDiv");
const toggleImagebtn = document.getElementById("toggleImages");

buttonImage.addEventListener("click", showImg);
toggleImagebtn.addEventListener("click", toggleImage);

// function showImg(){
//     const catImg = document.getElementById("catImage");
//     if(catImg.style.display == 'none'){
//         catImg.style.display = 'block';
//     }else if(catImg.style.display != 'none'){
//         catImg.style.display = 'none';
//     }
    
// }


function showImg(){
    let catImage = document.createElement('img');
            catImage.src="https://t4.ftcdn.net/jpg/00/97/58/97/360_F_97589769_t45CqXyzjz0KXwoBZT9PRaWGHRk5hQqQ.jpg";
            divimg.appendChild(catImage);
}


function toggleImage(parent){
    let catImage = document.createElement('img');
    catImage.setAttribute("id", "image")
    if(toggle == 0){
        imgDivToggle.innerHTML = '';
        catImage.src="http://placekitten.com/200/300";
        imgDivToggle.appendChild(catImage);
        toggle = 1;
       
    }else if(toggle == 1){
        imgDivToggle.innerHTML = '';
        catImage.src="http://placekitten.com/g/200/300";
        imgDivToggle.appendChild(catImage);
        toggle = 0;
    }
   
}