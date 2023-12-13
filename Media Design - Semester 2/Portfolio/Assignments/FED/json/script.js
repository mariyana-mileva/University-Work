const members = document.getElementById('peoplelist')

fetch('memebers.json')
.then(response => response.json())
.then(data=> jsononscreen(data))

function jsononscreen(data){
    console.log(data)
    data.forEach(element => {
        console.log (element)
        members.innerHTML += "<li>"+ element.name +"</li>"
        members.innerHTML += "<img src ='"+element.picture+ "' alt='' />"
    });
}