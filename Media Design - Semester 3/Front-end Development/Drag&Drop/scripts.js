// # Select all elements with the class 'cube' and store them in the 'cubes'.
const cubes = document.querySelectorAll('.cube');

// # Select all elements with the class 'panel' and store them in the 'panel'.
const panel = document.querySelectorAll('.panel');

// # Loop through each cube element in the 'cubes'.
cubes.forEach(cube => {

     // # Add a 'dragstart' event listener to the current cube.
    cube.addEventListener('dragstart', () => {

        // # When a drag operation starts, add the 'dragging' class to the cube.
        cube.classList.add('dragging');
    });

    // # Add a 'dragend' event listener to the current cube.
    cube.addEventListener('dragend', () => {

        // # When the drag operation ends, remove the 'dragging' class from the cube.
        cube.classList.remove('dragging');
    });
});


// # Loop through each panel element in the 'panel'. 
panel.forEach(panel => {

    // # Add a 'dragover' event listener to the current panel.
    panel.addEventListener('dragover', (e) => {

        // # Prevent the default behavior of dragover to allow dropping.
        e.preventDefault();
    });

    // # Add a 'drop' event listener to the current panel.
    panel.addEventListener('drop', () => {
        
        // # Find the currently dragged cube by selecting the element with the 'dragging' class.
        const currentlyDragged = document.querySelector('.dragging');
        
        // # Check if the current panel does not already contain the currently dragged cube,
        // and the number of children in the panel is less than 4 (limiting the number of cubes per panel).
        if (!panel.contains(currentlyDragged) && panel.children.length < 4) {

            // # Append the currently dragged cube to the current panel.
            panel.appendChild(currentlyDragged);
        }
    });
});






//#############################################################

// var whichPanel = 1;
// panel.forEach(panel => {
//     var counter = 0;
//     cubesInPanel =  panel.querySelectorAll('.cube');
    
//     console.log(cubesInPanel);
//     cubesInPanel.forEach(cube => {
//         if(whichPanel == 1){
//             if(counter % 2 == 0){
//                 cube.classList.add('blue');
//             }else{
//                 cube.classList.add('green')
//             }
//         }
//         if(whichPanel == 2){
//             if(counter % 2 == 0){
//                 cube.classList.add('red');
//             }else{
//                 cube.classList.add('orange')
//             }
//         }
//         counter++;
//     });

//     whichPanel++;
// });

