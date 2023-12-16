import React, { useState } from "react";
import "./App.css";

function App() {
  const [tasks, setTasks] = useState([]);
  const [newTask, setNewTask] = useState("");
  const [filter, setFilter] = useState("all"); // all, active, completed
  const filteredTasks = tasks.filter((task) => {
    if (filter === "active") return !task.completed;
    if (filter === "completed") return task.completed;
    return true;
  });

  function handleInputChange(e) {
    setNewTask(e.target.value);
  }
  function addTask() {
    if (newTask.trim() !== "") {
      const newTaskItem = { id: Date.now(), text: newTask, completed: false };
      setTasks([...tasks, newTaskItem]);
      setNewTask("");
    }
  }

  function toggleCompletion(id) {
    const updatedTasks = tasks.map((task) => {
      if (task.id === id) {
        return { ...task, completed: !task.completed };
      }
      return task;
    });
    setTasks(updatedTasks);
  }

  function deleteTask(id) {
    console.log(id);
    const updatedTasks = tasks.filter((task) => task.id !== id);
    setTasks(updatedTasks);
  }

  return (
    <div className="App">
      <h1>To-Do List</h1>
      <input
        type="text"
        value={newTask}
        onChange={handleInputChange}
        placeholder="Add a new task..."
      />
      <button onClick={addTask}>Add</button>
      <ul>
        {filteredTasks.map((task) => (
          <li key={task.id}>
            <input
              type="checkbox"
              checked={task.completed}
              onChange={() => toggleCompletion(task.id)}
            />
            {task.text}
            <button class="deleteButton" onClick={() => deleteTask(task.id)}>X</button>

          </li>
        ))}
      </ul>
      <div>
        Filter:
        <button onClick={() => setFilter("all")}>All</button>
        <button onClick={() => setFilter("active")}>Active</button>
        <button onClick={() => setFilter("completed")}>Completed</button>
      </div>
    </div>
  );
}
export default App;
