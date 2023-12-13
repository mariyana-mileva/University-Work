

function addTask() {
    var taskInput = document.getElementById("taskInput");
    var taskList = document.getElementById("taskList");

    if (taskInput.value !== "") {
        var task = document.createElement("li");
        task.innerText = taskInput.value;

        var removeButton = document.createElement("button");
        removeButton.className = "remove-button";
        removeButton.innerText = "Remove";
        removeButton.onclick = function() {
            removeTask(this.parentNode);
        };

        task.appendChild(removeButton);
        taskList.appendChild(task);
        taskInput.value = "";
    }
}

function removeTask(task) {
    task.parentNode.removeChild(task);
}