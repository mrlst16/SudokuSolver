import './App.css';
import { Outlet, Route, Router } from 'react-router';
import { Solver } from './Solver';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Solver />,
  }]);

function App() {
  const routes = [{}];
  return (
      <div className="App">
        <RouterProvider router={router} />
      </div>
  );  
}

export default App;
