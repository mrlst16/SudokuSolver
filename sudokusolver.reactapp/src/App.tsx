import React from 'react';
import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="App">
        <h1>Sudoku Solver</h1>
        <main>
          <h3>Welcome to the sudoku solver!</h3>
          <p>
            Place a string of 81 numbers into the text area below.  This will be parsed as "Every 9 numbers is a row, starting from the top"
          </p>
        </main>
        <textarea>
        </textarea>
        <button type='submit'></button>
    </div>
  );
}

export default App;
