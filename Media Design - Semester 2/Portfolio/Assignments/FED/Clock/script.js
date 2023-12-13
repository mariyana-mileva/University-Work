function updateClock() {


  
  var currentTime = new Date();

  var hourHand = document.getElementById("hourHand");
  var minuteHand = document.getElementById("minuteHand");
  var secondHand = document.getElementById("secondHand");

  var hour = currentTime.getHours() % 12; 
  var minute = currentTime.getMinutes();
  var second = currentTime.getSeconds();



  //for the clock degrees, I used a website calculating the degrees of the clock --> https://mathigon.org/task/clock-angles
  var hourRotation = (hour * 30) + (minute * 0.5); 
  var minuteRotation = (minute * 6) + (second * 0.1); 
  var secondRotation = second * 6; 


  hourHand.style.transform = "rotate(" + hourRotation + "deg)";
  minuteHand.style.transform = "rotate(" + minuteRotation + "deg)";
  secondHand.style.transform = "rotate(" + secondRotation + "deg)";
}

setInterval(updateClock, 1000);